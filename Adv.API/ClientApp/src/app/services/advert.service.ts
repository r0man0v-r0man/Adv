import { Injectable, Injector } from '@angular/core';
import { NzModalComponent } from 'ng-zorro-antd/modal/modal.component';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { FlatRentModel } from '../models/flatRentModel';
import { FlatSaleModel } from '../models/flatSaleModel';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants';
import { AuthService } from './auth.service';
import { FlatUpdateModel } from '../models/flatUpdateModel';

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
  /** создание объявления "квартира сдать" */
  createAdvertFlatRent(modal: NzModalComponent){ 
    //модель объявления - сдать квартиру
    const flatRent: FlatRentModel = { 
      ...modal.getContentComponent().flatRentForm.value
    }    
    this.createFlatRent(flatRent).subscribe(response => {
      if(response){
        this.showUserSuccessNotification();
        this.navigateToNewAdvert(response.id);
      }
    });
  }
  /** переход на страницу с объявлением */
  private navigateToNewAdvert(id:number){
    this.router.navigate(['flats/', id])
  }
  /** создание объявления "дом продать" */
  createAdvertHouseSale(modal: NzModalComponent){
    console.log(modal);

  }
  /** создание объявления "дом сдать" */
  createAdvertHouseRent(modal: NzModalComponent){
    console.log(modal);
    
  }
  /** создание объявления "квартира продать" */
  createAdvertFlatSale(modal: NzModalComponent){
    console.log(modal);
    // модель объявления - продать квартиру
    const flatSale: FlatSaleModel = {
      ...modal.getContentComponent().flatSaleForm.value
    }
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
  delete(id: number){
    return this.httpService.delete<boolean>(this.deleteFlatUrl + '/' + id, { headers: this.authService.SecureHeaders });
  }
  update(updateFlat:FlatUpdateModel){
    return this.httpService.put<boolean>(this.updateFlatUrl, updateFlat, { headers: this.authService.SecureHeaders });
  }
}
