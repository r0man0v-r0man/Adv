import { Component, OnInit } from '@angular/core';
import { HouseRentModel } from 'src/app/models/house-rent.model';
import { FilterOptions } from 'src/app/models/filterOptions';
import { Router } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';
import { City } from 'src/app/models/city.model';

@Component({
  selector: 'houses-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.less']
})
export class RentComponent implements OnInit {

  listHouseRent: HouseRentModel[] = [];
  filterOption: FilterOptions;
  initLoading: boolean = true;
  isShowMoreButton: boolean = false;
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
    this.advertService.getHouseRents(this.pageNumber, this.filterOption).subscribe(response => {
      if(response && response.length !== 0){
        this.listHouseRent = [...response];
        this.initLoading = false;
        this.isShowMoreButton = true;
      }
      else{
        this.listHouseRent = [...response];
        this.initLoading = false;
        this.isShowMoreButton = false;
      }
      this.allowToShowMoreButton(response, false);
    })
  }
  /** Определяемся, когда показывать кнопку "загрузить еще" */
  private allowToShowMoreButton(response: HouseRentModel[], isLoadMore: boolean) {
    if(isLoadMore){
      response && response.length > 0 ? this.isShowMoreButton = true : this.isShowMoreButton = false;
    }else{
      response && response.length >= 20 ? this.isShowMoreButton = true : this.isShowMoreButton = false; 
    }
  }
  /** переход на страницу с информацией об объявлении */
  onCardClick(advert: HouseRentModel){
      this.router.navigate(['house', 'rent', advert.id], );
  }
  /** Загрузить еще объявляений */
  onLoadMore(){
    this.initLoading = true;
    this.pageNumber++;
    this.advertService.getHouseRents(this.pageNumber, this.filterOption).subscribe(response => {
      if(response && response.length > 0){
        this.listHouseRent = [...response];
      }
      this.allowToShowMoreButton(response, true);
    })

    this.initLoading = false;
    
  }
}
