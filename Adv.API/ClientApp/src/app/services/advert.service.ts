import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { FlatRentModel } from '../models/flatRentModel';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Constants } from '../constants';
import { AuthService } from './auth.service';
import { FlatSaleModel } from '../models/flatSaleModel';
import { HouseSaleModel } from '../models/house-sale.model';
import { FlatUpdateModel } from '../models/flatUpdateModel';
import { HouseRentModel } from '../models/house-rent.model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AdvertService {
  private addFlatRentURL: string = Constants.addFlatRent;
  private addFlatSaleUrl: string = Constants.addFlatSale;
  private addHouseRentUrl: string = Constants.addHouseRent;
  private addHouseSaleUrl: string = Constants.addHouseSale;
  private deleteFlatUrl: string = Constants.deleteFlat;
  private updateFlatUrl: string = Constants.updateFlat;
  private getFlatRentUrl: string = Constants.getFlatRent;
  /** for SSR */
  private baseUrl: string;

  constructor(
    private httpService: HttpClient,
    private router: Router,
    private injector: Injector,
    private authService: AuthService,
    private notificationService: NzNotificationService
  ) {
    this.baseUrl = this.injector.get('BASE_URL');
  }
  
  /** переход на страницу с объявлением квартира */
  private navigateToNewFlatAdvert(id:number){
    this.router.navigate(['flat/', id])
  }
  /** переход на страинцу с объявлением дом */
  private navigateToNewHouseAdvert(id: number){
    this.router.navigate(['house/', id]);
  }
  /** показывает уведомление о создании объявления */
  private showUserSuccessNotification(){
    this.notificationService.success(
      'Объявление создано',
      'Все хорошо, вы добавили новое объявление',
      {
        nzPauseOnHover: true
      })
  }
  /** создание объявления дом сдать */
  addHouseRent(advert: HouseRentModel){
    this.httpService.post<HouseRentModel>(this.addHouseRentUrl, advert, { headers: this.authService.SecureHeaders}).pipe(
      map((response: HouseRentModel)=>{
        this.navigateToNewHouseAdvert(response?.id);
        this.showUserSuccessNotification();
      })).subscribe();
  }
  /** создание объявления дом продать */
  addHouseSale(advert: HouseSaleModel){
    this.httpService.post<HouseSaleModel>(this.addHouseSaleUrl, advert, { headers: this.authService.SecureHeaders}).pipe(
      map((response: HouseSaleModel)=>{
        this.navigateToNewHouseAdvert(response?.id);
        this.showUserSuccessNotification();
      })
    ).subscribe();
  }
  /** создать объявление квартира продать */
  addFlatSale(advert: FlatSaleModel){
    this.httpService.post<FlatSaleModel>(this.addFlatSaleUrl, advert, { headers: this.authService.SecureHeaders}).pipe(
      map((response:FlatSaleModel)=>{
        this.navigateToNewFlatAdvert(response?.id);
        this.showUserSuccessNotification();
      })
    ).subscribe();
  }
  /** создать объявление квартира сдать */
  addFlatRent(advert: FlatRentModel){
    this.httpService.post<FlatRentModel>(this.addFlatRentURL, advert, { headers: this.authService.SecureHeaders}).pipe(
      map((response: FlatRentModel)=>{
        this.navigateToNewFlatAdvert(response?.id);
        this.showUserSuccessNotification();
      })
    ).subscribe();
  }
  /** удалить объявление */
  delete(id: number){
    return this.httpService.delete<boolean>(this.deleteFlatUrl + '/' + id, { headers: this.authService.SecureHeaders });
  }
  /** обновить объявление */
  update(updateFlat:FlatUpdateModel){
    return this.httpService.put<boolean>(this.updateFlatUrl, updateFlat, { headers: this.authService.SecureHeaders });
  }
  /** получить объявление квартира-сдать */
  getFlatRent(id: number){
    let params = new HttpParams();
    params = params.append("id", id.toString());
    return this.httpService.get<FlatRentModel>(`${this.baseUrl}${this.getFlatRentUrl}`, { params : params});
  }
}