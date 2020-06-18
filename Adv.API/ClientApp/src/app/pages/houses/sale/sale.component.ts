import { Component, OnInit } from '@angular/core';
import { HouseSaleModel } from 'src/app/models/house-sale.model';
import { FilterOptions } from 'src/app/models/filterOptions';
import { AdvertService } from 'src/app/services/advert.service';
import { Router } from '@angular/router';
import { City } from 'src/app/models/city.model';

@Component({
  selector: 'houses-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.less']
})
export class SaleComponent implements OnInit {

  listHouseSale: HouseSaleModel[] = [];
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
  /**
   * Показать объявления
   * @param city Город, по которому фильтруем
   */
  showAdverts(city: City){
    this.filterOption = { city: city };
    this.advertService.getHouseSales(this.pageNumber, this.filterOption).subscribe(response => {
      if(response && response.length !== 0){
        this.listHouseSale = [...response];
        this.initLoading = false;
        this.isShowMoreButton = true;
      }
      else{
        this.listHouseSale = [...response];
        this.initLoading = false;
        this.isShowMoreButton = false;
      }
      this.allowToShowMoreButton(response, false);
    })
  }
  /** Определяемся, когда показывать кнопку "загрузить еще" */
  private allowToShowMoreButton(response: HouseSaleModel[], isLoadMore: boolean) {
    if(isLoadMore){
      response && response.length > 0 ? this.isShowMoreButton = true : this.isShowMoreButton = false;
    }else{
      response && response.length >= 20 ? this.isShowMoreButton = true : this.isShowMoreButton = false; 
    }
  }
  /** переход на страницу с информацией об объявлении */
  onCardClick(advert: HouseSaleModel){
      this.router.navigate(['house', 'sale', advert.id], );
  }
  /** Загрузить еще объявляений */
  onLoadMore(){
    this.initLoading = true;
    this.pageNumber++;
    this.advertService.getHouseSales(this.pageNumber, this.filterOption).subscribe(response => {
      if(response && response.length > 0){
        this.listHouseSale = [...response];
      }
      this.allowToShowMoreButton(response, true);
    })

    this.initLoading = false;
    
  }
}
