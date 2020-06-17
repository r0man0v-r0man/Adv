import { Component, OnInit, Input } from '@angular/core';
import { FilterOptions } from 'src/app/models/filterOptions';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { Router } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';
import { City } from 'src/app/models/city.model';

@Component({
  selector: 'flats-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.less']
})
export class SaleComponent implements OnInit {

  listFlatSale: FlatSaleModel[] = [];
  filterOption: FilterOptions;
  initLoading: boolean = true;
  isShowMoreButton: boolean = true;
  pageNumber: number = 1;
  constructor(
    private advertService: AdvertService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }
  showAdverts(city: City){
    this.filterOption = { city: city };
    this.advertService.getFlatSales(this.pageNumber, this.filterOption).subscribe(response => {
      if(response && response.length !== 0){
        this.listFlatSale = [...response];
        this.initLoading = false;
        this.isShowMoreButton = true;
      }
      else{
        this.listFlatSale = [...response];
        this.initLoading = false;
        this.isShowMoreButton = false;
      }
      this.allowToShowMoreButton(response, false);
    })
  }
  private allowToShowMoreButton(response: FlatSaleModel[], isLoadMore: boolean) {
    if(isLoadMore){
      response && response.length > 0 ? this.isShowMoreButton = true : this.isShowMoreButton = false;
    }else{
      response && response.length >= 20 ? this.isShowMoreButton = true : this.isShowMoreButton = false; 
    }
  }
  private onCardClick(advert: FlatSaleModel){
      this.router.navigate(['flat', 'sale', advert.id], );
  }

  private onLoadMore(){
    this.initLoading = true;
    this.pageNumber++;
    this.advertService.getFlatSales(this.pageNumber, this.filterOption).subscribe(response => {
      if(response && response.length > 0){
        this.listFlatSale = [...response];
      }
      this.allowToShowMoreButton(response, true);
    })

    this.initLoading = false;
    
  }
}
