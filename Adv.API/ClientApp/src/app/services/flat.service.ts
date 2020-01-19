import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FlatModel } from '../models/flatModel';

@Injectable({
  providedIn: 'root'
})
export class FlatService {
  
  headers = new HttpHeaders().set('content-type', 'application/json');

  constructor(
    private httpService: HttpClient
    ) { }
    
  /**
   * Get flats
   * @param url api url for fething flats
   * @param pageNumber number for fetch flats
   */
  getFlats(url:string, pageNumber: number){
    return this.httpService.get<FlatModel[]>(url + '/' + pageNumber)
  }
  
  getFlat(url: string, flatId: number){
    const secureHeader = this.headers.append("Authorization", 'Bearer ' + localStorage.getItem('access_token'));
    return this.httpService.get<FlatModel>(url + '/' + flatId, { headers :  secureHeader})
  }
  createFlat(url: string, newFlat: FlatModel){
    return this.httpService.post<FlatModel>(url, newFlat, { headers: this.headers })
  }
  delete(url: string, id: number){
    return this.httpService.delete(url + '/' + id)
  }

}
