import { Component, OnInit, Input } from '@angular/core';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { HouseSaleModel } from 'src/app/models/house-sale.model';
import { HouseRentModel } from 'src/app/models/house-rent.model';
import { TypeOfAdvert } from 'src/app/models/advertType';
import { Router } from '@angular/router';

@Component({
  selector: 'app-advert-card',
  templateUrl: './advert-card.component.html',
  styleUrls: ['./advert-card.component.less']
})
export class AdvertCardComponent implements OnInit {
  /** объявление */
  @Input() item: FlatSaleModel | FlatRentModel | HouseSaleModel | HouseRentModel;
  /** тип объявления */
  @Input() advertType:TypeOfAdvert;
  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  /** переход на страницу с информацией об объявлении */
  onCardClick(item: FlatSaleModel | FlatRentModel | HouseSaleModel | HouseRentModel) {
    if (this.advertType === TypeOfAdvert.flatRent) this.router.navigate(['flat', 'rent', item.id]);
    if (this.advertType === TypeOfAdvert.flatSale) this.router.navigate(['flat', 'sale', item.id]);
    if (this.advertType === TypeOfAdvert.houseRent) this.router.navigate(['house', 'rent', item.id]);
    if (this.advertType === TypeOfAdvert.houseSale) this.router.navigate(['house', 'sale', item.id]);
  }
}
