import { Component, OnInit } from '@angular/core';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { AdvertService } from 'src/app/services/advert.service';
import { FilterOptions } from 'src/app/models/filterOptions';
import { IComponent } from 'src/app/models/yandex';
import { TypeOfAdvert } from 'src/app/models/advertType';

@Component({
  selector: 'app-flats-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.less']
})
export class RentComponent implements OnInit {
  typeOfAdvert = TypeOfAdvert.flatRent;
  listFlatRent: FlatRentModel[] = [];
  filterOption: FilterOptions;
  initLoading = true;
  isShowMoreButton = false;
  pageNumber = 1;
  isAnyAdverts = false;
  constructor(
    private advertService: AdvertService,
  ) { }

  ngOnInit(): void {
  }
  /**
   * Показать объявления
   * @param province Город, по которому фильтруем
   */
  showAdverts(province: IComponent) {
    province ? this.showFilterAdverts(province) : this.showAnyAdverts();
  }
  /** объявления без фильтра, любые */
  showAnyAdverts() {
    this.isAnyAdverts = true;
    this.advertService.getAnyFlatRents(this.pageNumber).subscribe(response => {
      this.AddAdvertsToList(response);
    });
  }
  /** Показать объявления с фильтром */
  showFilterAdverts(province: IComponent) {
    this.isAnyAdverts = false;
    this.filterOption = { province: province };
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
      response.forEach(advert => {
        this.listFlatRent.push(advert)
      })
    }
    this.allowToShowMoreButton(response, true);
  }
}
