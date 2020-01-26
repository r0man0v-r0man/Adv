import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FlatModel } from '../models/flatModel';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class FlatService {

  constructor(
    private httpService: HttpClient,
    private authService: AuthService
    ) { }
    
  /**
   * Get flats
   * @param url api url for fething flats
   * @param pageNumber number for fetch flats
   */
  getFlats(url:string, pageNumber: number){
    return this.httpService.get<FlatModel[]>(url + '/' + pageNumber)
  }
  /**
   * get one flat
   * @param url api url
   * @param flatId flat id
   */
  getFlat(url: string, flatId: number){
    return this.httpService.get<FlatModel>(url + '/' + flatId)
  }
  /**
   * Create new flat advert
   * @param url 
   * @param newFlat flatModel object
   */
  createFlat(url: string, newFlat: FlatModel){
    return this.httpService.post<FlatModel>(url, newFlat, { headers: this.authService.SecureHeaders });
  }
  delete(url: string, id: number){
    return this.httpService.delete(url + '/' + id)
  }

}
