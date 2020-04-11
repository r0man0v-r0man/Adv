import { Injectable, Injector } from '@angular/core';
import { Constants } from '../constants';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AuthService } from './auth.service';
import { FlatModel } from '../models/flatModel';
import { FlatUpdateModel } from '../models/updateModels/flatUpdateModel';
import { NzNotificationService, NzModalComponent } from 'ng-zorro-antd';
import { Router } from '@angular/router';
import { SearchFlatCriteria } from '../models/searchFlatCriteria';

@Injectable({
  providedIn: 'root'
})
export class AdvertService {
  private searchFlatUrl: string = Constants.searchFlat;
  private createFlatUrl: string = Constants.flat;
  private flatsUrl: string = Constants.getAllFlats;
  private flatUrl:string = Constants.flat;
  private deleteFlatUrl: string = Constants.deleteFlat;
  private updateFlatUrl: string = Constants.updateFlat;
/** for SSR */
  private baseUrl: string;

  constructor(
    private httpService: HttpClient,
    private authService: AuthService,
    private injector: Injector,
    private notificationService: NzNotificationService,
    private router: Router
    ) {
      this.baseUrl = this.injector.get('BASE_URL');
     }
  /** get user's flats only */
  getUserFlats(userId: string, pageNumber: number){
    let params = new HttpParams();
    params = params.append("userId", userId);
    params = params.append("pageNumber", pageNumber.toString());
    return this.httpService.get<FlatModel[]>(this.flatsUrl, {params: params})
  }
  /**
   * Get flats
   * @param pageNumber number for fetch flats
   */
  getFlats( pageNumber: number){
    return this.httpService.get<FlatModel[]>(`${this.baseUrl}${this.flatsUrl}/${pageNumber}`)
  }
  /**
   * get one flat
   * @param flatId flat id
   */
  getFlat(flatId: number){
    return this.httpService.get<FlatModel>(`${this.baseUrl}${this.flatUrl}/${flatId}`)
  }
  /** создание объявления */
  createAdvert(modal: NzModalComponent){
    //helper.advertType - сдать/продать и helper.realEstateType - квартира/дом
    const helper = modal.getContentComponent().helperForm.value;
    
    if(helper.advertType === 'сдать' && helper.realEstateType === 'квартира'){   
      //модель объявления - сдать квартиру
      const flatRent: FlatModel = { 
        ...modal.getContentComponent().flatRentForm.value
      }    
      this.createFlat(flatRent).subscribe(response => {
        if(response){
          this.showUserSuccessNotification();
          this.navigateToNewAdvert(response.id);
        }
      });
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
  /** переход на страницу с объявлением */
  private navigateToNewAdvert(id:number){
    this.router.navigate(['flats/', id])
  }
  /**
   * Создание объявления - квартира снять
   * @param newFlat flatModel object
   */
  private createFlat(newFlat: FlatModel){
    return this.httpService.post<FlatModel>(this.createFlatUrl, newFlat, { headers: this.authService.SecureHeaders });
  }
  delete(id: number){
    return this.httpService.delete<boolean>(this.deleteFlatUrl + '/' + id, { headers: this.authService.SecureHeaders });
  }
  update(updateFlat:FlatUpdateModel){
    return this.httpService.put<boolean>(this.updateFlatUrl, updateFlat, { headers: this.authService.SecureHeaders });
  }
  /** поиск квартир по параметрам */
  findFlats(criteria: SearchFlatCriteria){
    return this.httpService.post<FlatModel[]>(`${this.baseUrl}${this.searchFlatUrl}`, criteria, { headers: this.authService.headers});
  }
}
