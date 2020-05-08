import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { FlatRentModel } from '../models/flatRentModel';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants';
import { AuthService } from './auth.service';
import { FlatSaleModel } from '../models/flatSaleModel';
import { HouseSaleModel } from '../models/house-sale.model';
import { FlatUpdateModel } from '../models/flatUpdateModel';
import { HouseRentModel } from '../models/house-rent.model';

@Injectable({
  providedIn: 'root'
})
export class AdvertService {
  private createFlatUrl: string = Constants.flat;
  private deleteFlatUrl: string = Constants.deleteFlat;
  private updateFlatUrl: string = Constants.updateFlat;
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
  
  /** переход на страницу с объявлением */
  private navigateToNewAdvert(id:number){
    this.router.navigate(['flats/', id])
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
  /** создание объявления: квартира - сдать */
  private createFlatRent(newFlat: FlatRentModel){
    return this.httpService.post<FlatRentModel>(this.createFlatUrl, newFlat, { headers: this.authService.SecureHeaders });
  }
  /** создание объявления */
  add(advert: HouseSaleModel | HouseRentModel){
    console.log(advert);
    
  }
  delete(id: number){
    return this.httpService.delete<boolean>(this.deleteFlatUrl + '/' + id, { headers: this.authService.SecureHeaders });
  }
  update(updateFlat:FlatUpdateModel){
    return this.httpService.put<boolean>(this.updateFlatUrl, updateFlat, { headers: this.authService.SecureHeaders });
  }
}