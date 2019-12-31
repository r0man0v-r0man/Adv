import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, map, retry } from 'rxjs/operators'
import { throwError, Observable } from 'rxjs';
import { AppError } from '../app-errors/app-error';
import { NotFoundError } from '../app-errors/not-found-error';
import { BadInput } from '../app-errors/bad-input';
import { FlatModel } from '../models/flatModel';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  headers = new HttpHeaders().set('content-type', 'application/json');

  constructor(
    private httpService: HttpClient) { }


  /**
   * Get flats
   * @param url api url for fething flats
   * @param pageNumber number for fetch flats
   */
  getFlats(url:string, pageNumber: number){
    return this.httpService.get<FlatModel[]>(url + '/' + pageNumber)
      .pipe(
        catchError(this.handleError)
      )
  }
  
  getFlat(url: string, flatId: number){
    return this.httpService.get<FlatModel>(url + '/' + flatId)
      .pipe(
        catchError(this.handleError)
      )
  }
  createFlat(url: string, newFlat: FlatModel){
    return this.httpService.post<FlatModel>(url, newFlat, { headers: this.headers })
      .pipe(
        catchError(this.handleError)
      )
  }
  delete(url: string, id: number){
    return this.httpService.delete(url + '/' + id)
      .pipe(
        catchError(this.handleError)
      )
  }
  deleteFile(url: string, fileName: string){
    return this.httpService.delete<boolean>(url + '/' + fileName)
      .pipe(
        catchError(this.handleError)
      )
  }
  private handleError(error: HttpErrorResponse){
    if(error.status === 400)
    return throwError(new BadInput(error.error));
  
    if(error.status === 404)
    return throwError(new NotFoundError(error.error));
    
  return throwError(new AppError(error));
  }
}
