import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FlatModel } from '../models/flatModel';
import { AuthService } from './auth.service';
import { Constants } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class FlatService {
  createFlatUrl: string = Constants.flat;
  flatsUrl: string = Constants.getAllFlats;
  flatUrl:string = Constants.flat;
  deleteFlatUrl: string = Constants.deleteFlat;

  constructor(
    private httpService: HttpClient,
    private authService: AuthService
    ) { }
    
  /**
   * Get flats
   * @param pageNumber number for fetch flats
   */
  getFlats( pageNumber: number){
    return this.httpService.get<FlatModel[]>(this.flatsUrl + '/' + pageNumber)
  }
  /**
   * get one flat
   * @param flatId flat id
   */
  getFlat( flatId: number){
    return this.httpService.get<FlatModel>(this.flatUrl + '/' + flatId)
  }
  /**
   * Create new flat advert
   * @param url 
   * @param newFlat flatModel object
   */
  createFlat(newFlat: FlatModel){
    return this.httpService.post<FlatModel>(this.createFlatUrl, newFlat, { headers: this.authService.SecureHeaders });
  }
  delete(id: number){
    return this.httpService.delete<boolean>(this.deleteFlatUrl + '/' + id, { headers: this.authService.SecureHeaders });
  }

}
