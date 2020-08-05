import { Component, OnInit, Input } from '@angular/core';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { HouseSaleModel } from 'src/app/models/house-sale.model';
import { HouseRentModel } from 'src/app/models/house-rent.model';
import { TypeOfAdvert } from 'src/app/models/advertType';
import { AdvertService } from 'src/app/services/advert.service';

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
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
  }

  /** переход на страницу с информацией об объявлении */
  onCardClick(item: FlatSaleModel | FlatRentModel | HouseSaleModel | HouseRentModel) {
    this.advertService.navigateToAdvert(item, this.advertType);
  }
}
