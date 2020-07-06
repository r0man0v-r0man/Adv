import { Component, OnInit } from '@angular/core';
import { HouseRentModel } from 'src/app/models/house-rent.model';
import { FilterOptions } from 'src/app/models/filterOptions';
import { Router } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'app-houses-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.less']
})
export class RentComponent implements OnInit {

  listHouseRent: HouseRentModel[] = [];
  filterOption: FilterOptions;
  initLoading = true;
  isShowMoreButton = false;
  pageNumber = 1;
  isAnyAdverts = false;

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
  showAdverts(city: any) {
    city ? this.showFilterAdverts(city) : this.showAnyAdverts();
  }
  /** объявления без фильтра, любые */
  showAnyAdverts() {
    this.isAnyAdverts = true;
    this.advertService.getAnyHouseRents(this.pageNumber).subscribe(response => {
      this.AddAdvertsToList(response);
    });
  }
  /** Показать объявления с фильтром */
  showFilterAdverts(city: any) {
    this.isAnyAdverts = false;
    this.filterOption = { city: city };
    this.advertService.getHouseRents(this.pageNumber, this.filterOption).subscribe(response => {
      this.AddAdvertsToList(response);
    });
  }
  /** добавить объявления */
  private AddAdvertsToList(response: HouseRentModel[]) {
    if (response && response.length !== 0) {
      this.listHouseRent = [...response];
      this.initLoading = false;
      this.isShowMoreButton = true;
    } else {
      this.listHouseRent = [...response];
      this.initLoading = false;
      this.isShowMoreButton = false;
    }
    this.allowToShowMoreButton(response, false);
  }
  /** Определяемся, когда показывать кнопку "загрузить еще" */
  private allowToShowMoreButton(response: HouseRentModel[], isLoadMore: boolean) {
    if (isLoadMore) {
      response && response.length > 0 ? this.isShowMoreButton = true : this.isShowMoreButton = false;
    } else {
      response && response.length >= 20 ? this.isShowMoreButton = true : this.isShowMoreButton = false;
    }
  }
  /** переход на страницу с информацией об объявлении */
  onCardClick(advert: HouseRentModel) {
      this.router.navigate(['house', 'rent', advert.id]);
  }
  /** Загрузить еще объявляений */
  onLoadMore() {
    this.initLoading = true;
    this.pageNumber++;
    if (this.isAnyAdverts) {
      this.advertService.getAnyHouseRents(this.pageNumber).subscribe(response => {
        this.addLoadMoreAdvertsToList(response);
      });
    } else {
      this.advertService.getHouseRents(this.pageNumber, this.filterOption).subscribe(response => {
        this.addLoadMoreAdvertsToList(response);
      });
    }
    this.initLoading = false;
  }
  /** Добавить еще объявлений  */
  private addLoadMoreAdvertsToList(response: HouseRentModel[]) {
    if (response && response.length > 0) {
      response.forEach(advert => {
        this.listHouseRent.push(advert)
      })
    }
    this.allowToShowMoreButton(response, true);
  }
}
