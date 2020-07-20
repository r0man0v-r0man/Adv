import { Component, OnInit, Input } from '@angular/core';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { HouseSaleModel } from 'src/app/models/house-sale.model';
import { HouseRentModel } from 'src/app/models/house-rent.model';

@Component({
  selector: 'app-advert-card',
  templateUrl: './advert-card.component.html',
  styleUrls: ['./advert-card.component.less']
})
export class AdvertCardComponent implements OnInit {
  @Input() item: FlatSaleModel | FlatRentModel | HouseSaleModel | HouseRentModel;
  constructor() { }

  ngOnInit(): void {
  }

  onCardClick(item: FlatSaleModel | FlatRentModel | HouseSaleModel | HouseRentModel) {
    console.log(item);
    
  }
}
