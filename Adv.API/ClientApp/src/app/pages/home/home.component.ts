import { Component, OnInit } from '@angular/core';
import { TypeOfAdvert } from 'src/app/models/advertType';
import { Router } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';

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
  constructor(
    private router: Router,
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.getLastFlatRent();
    console.log(this.advertFlatRent);
    
  }
  getLastFlatRent() {
    this.advertService.getLastFlatRent().subscribe(response => this.advertFlatRent = response);
  }
}
