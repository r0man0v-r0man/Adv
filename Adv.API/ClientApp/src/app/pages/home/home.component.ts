import { Component, OnInit } from '@angular/core';
import { TypeOfAdvert } from 'src/app/models/advertType';
import { AdvertService } from 'src/app/services/advert.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { HouseRentModel } from 'src/app/models/house-rent.model';
import { HouseSaleModel } from 'src/app/models/house-sale.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {
  flatRentType = TypeOfAdvert.flatRent;
  flatSaleType = TypeOfAdvert.flatSale;
  houseRentType = TypeOfAdvert.houseRent;
  houseSaleType = TypeOfAdvert.houseSale;
  advertFlatRent: FlatRentModel; 
  advertFlatSale: FlatSaleModel;
  advertHouseRent: HouseRentModel;
  advertHouseSale: HouseSaleModel;
  constructor(
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.getLastFlatRent();
    this.getLastFlatSale();
    this.getLastHouseRent();
    this.getLastHouseSale();
  }
  getLastFlatRent() {
    this.advertService.getLastFlatRent().subscribe(response => {
      this.advertFlatRent = { ...response }
    });
  }
  getLastFlatSale() {
    this.advertService.getLastFlatSale().subscribe(response => {
      this.advertFlatSale = { ...response }
    })
  }
  getLastHouseRent() {
    this.advertService.getLastHouseRent().subscribe(response => {
      this.advertHouseRent = { ...response }
    })
  }
  getLastHouseSale() {
    this.advertService.getLastHouseSale().subscribe(response => {
      this.advertHouseSale = { ...response }
    })
  }
}
