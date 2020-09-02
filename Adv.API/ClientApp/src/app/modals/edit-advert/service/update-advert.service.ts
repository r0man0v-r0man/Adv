import { Injectable } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DescriptionValidators } from 'src/app/pages/create-advert/validators/description.validators';
import { TypeOfAdvert } from 'src/app/models/advertType';
import { AdvertService } from 'src/app/services/advert.service';
import { Subject, Observable } from 'rxjs';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { HouseSaleModel } from 'src/app/models/house-sale.model';
import { HouseRentModel } from 'src/app/models/house-rent.model';

@Injectable()
export class UpdateAdvertService {
  form = new Subject<FormGroup>();
  advert = new Subject();
  constructor(
    private fb: FormBuilder,
    private advertService: AdvertService
  ) { }
  initForm(id: number, type: TypeOfAdvert) : Observable<FormGroup> {    
    return new Observable(observer => {
      if (type === TypeOfAdvert.flatRent) this.advertService.getFlatRent(id).subscribe(data => this.returnForm(observer, data));
      if (type === TypeOfAdvert.flatSale) this.advertService.getFlatSale(id).subscribe(data => this.returnForm(observer, data));
      if (type === TypeOfAdvert.houseRent) this.advertService.getHouseRent(id).subscribe(data => this.returnForm(observer, data));
      if (type === TypeOfAdvert.houseSale) this.advertService.getHouseSale(id).subscribe(data => this.returnForm(observer, data));
    })
  }
  private returnForm(observer, data: FlatSaleModel | FlatRentModel | HouseSaleModel | HouseRentModel) {
    observer.next(this.createForm(data));
    observer.complete();
  }

  private createForm(data: FlatSaleModel | FlatRentModel | HouseSaleModel | HouseRentModel) {
    return this.fb.group({
      price: [ data.price, [Validators.required]],
      phone: [ data.phone, [Validators.required, Validators.pattern('[0-9]*')]],
      description: [ data.description, [DescriptionValidators.notOnlySpace]]
    });
  }

}
