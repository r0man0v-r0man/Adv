import { Component, OnInit, Input } from '@angular/core';
import { FilterOptions } from 'src/app/models/filterOptions';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { Router } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'flats-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.less']
})
export class SaleComponent implements OnInit {
  listFlatSale: FlatSaleModel[] = [];
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
    this.advertService.getFlatSales(this.filterOption).subscribe(response => {
      if(response && response.length !== 0){
        this.listFlatSale = [...response];
        this.initLoading = false;
        this.isShowMoreButton = true;
      }
      else{
        this.initLoading = false;
        this.isShowMoreButton = false;
      }
    })
  }
  onCardClick(advert: FlatSaleModel){
      this.router.navigate(['flat', 'sale', advert.id], );
  }

}
