import { Component, OnInit, Input } from '@angular/core';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { AdvertService } from 'src/app/services/advert.service';
import { FilterOptions } from 'src/app/models/filterOptions';
import { Router } from '@angular/router';
import { City } from 'src/app/models/city.model';

@Component({
  selector: 'flats-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.less']
})
export class RentComponent implements OnInit {

  listFlatRent: FlatRentModel[] = [];
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
    this.showAnyAdverts();
  }
  /**
   * Показать объявления
   * @param city Город, по которому фильтруем
   */
  showAdverts(city: City) {
    city ? this.showFilterAdverts(city) : this.showAnyAdverts();
  }
  /** объявления без фильтра, любые */
  showAnyAdverts() {
    this.isAnyAdverts = true;
    this.advertService.getAnyFlatRents(this.pageNumber).subscribe(response => {
      this.AddAdvertsToList(response);
    });
  }
  /** Показать объявления с фильтром */
  showFilterAdverts(city: City) {
    this.isAnyAdverts = false;
    this.filterOption = { city: city };
    this.advertService.getFlatRents(this.pageNumber, this.filterOption).subscribe(response => {
      this.AddAdvertsToList(response);
    });
  }
  /** добавить объявления */
  private AddAdvertsToList(response: FlatRentModel[]) {
    if (response && response.length !== 0) {
      this.listFlatRent = [...response];
      this.initLoading = false;
      this.isShowMoreButton = true;
    } else {
      this.listFlatRent = [...response];
      this.initLoading = false;
      this.isShowMoreButton = false;
    }
    this.allowToShowMoreButton(response, false);
  }

  /** Определяемся, когда показывать кнопку "загрузить еще" */
  private allowToShowMoreButton(response: FlatRentModel[], isLoadMore: boolean) {
    if (isLoadMore) {
      response && response.length > 0 ? this.isShowMoreButton = true : this.isShowMoreButton = false;
    } else {
      response && response.length >= 20 ? this.isShowMoreButton = true : this.isShowMoreButton = false;
    }
  }
  /** переход на страницу с информацией об объявлении */
  onCardClick(advert: FlatRentModel) {
      this.router.navigate(['flat', 'rent', advert.id]);
  }
  /** Загрузить еще объявляений */
  onLoadMore() {
    this.initLoading = true;
    this.pageNumber++;
    if (this.isAnyAdverts) {
      this.advertService.getAnyFlatRents(this.pageNumber).subscribe(response => {
        this.addLoadMoreAdvertsToList(response);
      });
    } else {
      this.advertService.getFlatRents(this.pageNumber, this.filterOption).subscribe(response => {
        this.addLoadMoreAdvertsToList(response);
      });
    }
    this.initLoading = false;
  }
  /** Добавить еще объявлений  */
  private addLoadMoreAdvertsToList(response: FlatRentModel[]) {
    if (response && response.length > 0) {
      this.listFlatRent = [...response];
    }
    this.allowToShowMoreButton(response, true);
  }
}
