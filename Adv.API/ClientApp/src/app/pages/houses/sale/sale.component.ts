import { Component, OnInit, Input } from '@angular/core';
import { HouseSaleModel } from 'src/app/models/house-sale.model';
import { FilterOptions } from 'src/app/models/filterOptions';
import { AdvertService } from 'src/app/services/advert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'houses-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.less']
})
export class SaleComponent implements OnInit {
  listHouseSale: HouseSaleModel[] = [];
  @Input() filterOption: FilterOptions;
  initLoading: boolean = true;
  isShowMoreButton: boolean = true;
  constructor(
    private advertService: AdvertService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.initPage();    
  }

  initPage(){
    this.advertService.getHouseSales(this.filterOption).subscribe(response => {
      if(response && response.length !== 0){
        this.listHouseSale = [...response];
        this.initLoading = false;
        this.isShowMoreButton = true;
      }
      else{
        this.initLoading = false;
        this.isShowMoreButton = false;
      }
    })
  }
  onCardClick(advert: HouseSaleModel){
      this.router.navigate(['house', 'sale', advert.id], );
  }

}
