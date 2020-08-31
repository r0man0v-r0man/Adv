import { Injectable } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DescriptionValidators } from 'src/app/pages/create-advert/validators/description.validators';
import { TypeOfAdvert } from 'src/app/models/advertType';
import { AdvertService } from 'src/app/services/advert.service';
import { Subject } from 'rxjs';

@Injectable()
export class UpdateAdvertService {
  form = new Subject<FormGroup>();
  advert = new Subject();
  constructor(
    private fb: FormBuilder,
    private advertService: AdvertService
  ) { }
  initForm(id: number, type: TypeOfAdvert) {
    if (type === TypeOfAdvert.flatRent) this.advertService.getFlatRent(id).subscribe(data => this.advert.next(data));
    if (type === TypeOfAdvert.flatSale) this.advertService.getFlatSale(id).subscribe(data => this.advert.next(data));
    if (type === TypeOfAdvert.houseRent) this.advertService.getHouseRent(id).subscribe(data => this.advert.next(data));
    if (type === TypeOfAdvert.houseSale) this.advertService.getHouseSale(id).subscribe(data => this.advert.next(data));
    this.advert.subscribe((data: any) => {
      const form = this.fb.group({
        price: [ data.price, [Validators.required]],
        phone: [ data.phone, [Validators.required, Validators.pattern('[0-9]*')]],
        description: [ data.description, [DescriptionValidators.notOnlySpace]]
      });
      this.form.next(form);
    });
  }

}
