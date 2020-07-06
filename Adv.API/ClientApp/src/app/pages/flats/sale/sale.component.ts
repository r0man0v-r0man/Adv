import { Component, OnInit } from '@angular/core';
import { FilterOptions } from 'src/app/models/filterOptions';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { Router } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'app-flats-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.less']
})
export class SaleComponent implements OnInit {

  listFlatSale: FlatSaleModel[] = [];
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
    this.advertService.getAnyFlatSales(this.pageNumber).subscribe(response => {
      this.AddAdvertsToList(response);
    });
  }
  /** Показать объявления с фильтром */
  showFilterAdverts(city: any) {
    this.isAnyAdverts = false;
    this.filterOption = { city: city };
    this.advertService.getFlatSales(this.pageNumber, this.filterOption).subscribe(response => {
      this.AddAdvertsToList(response);
    });
  }
  /** добавить объявления */
  private AddAdvertsToList(response: FlatSaleModel[]) {
    if (response && response.length !== 0) {
      this.listFlatSale = [...response];
      this.initLoading = false;
      this.isShowMoreButton = true;
    } else {
      this.listFlatSale = [...response];
      this.initLoading = false;
      this.isShowMoreButton = false;
    }
    this.allowToShowMoreButton(response, false);
  }

  /** Определяемся, когда показывать кнопку "загрузить еще" */
  private allowToShowMoreButton(response: FlatSaleModel[], isLoadMore: boolean) {
    if (isLoadMore) {
      response && response.length > 0 ? this.isShowMoreButton = true : this.isShowMoreButton = false;
    } else {
      response && response.length >= 20 ? this.isShowMoreButton = true : this.isShowMoreButton = false;
    }
  }
  /** переход на страницу с информацией об объявлении */
  onCardClick(advert: FlatSaleModel) {
    this.router.navigate(['flat', 'sale', advert.id]);
  }
  /** Загрузить еще объявляений */
  onLoadMore() {
    this.initLoading = true;
    this.pageNumber++;
    if (this.isAnyAdverts) {
      this.advertService.getAnyFlatSales(this.pageNumber).subscribe(response => {
        this.addLoadMoreAdvertsToList(response);
      });
    } else {
      this.advertService.getFlatSales(this.pageNumber, this.filterOption).subscribe(response => {
        this.addLoadMoreAdvertsToList(response);
      });
    }
    this.initLoading = false;
  }
  /** Добавить еще объявлений  */
  private addLoadMoreAdvertsToList(response: FlatSaleModel[]) {
    if (response && response.length > 0) {
      response.forEach(advert => {
        this.listFlatSale.push(advert)
      })
    }
    this.allowToShowMoreButton(response, true);
  }
}
