import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, map, retry } from 'rxjs/operators'
import { throwError, Observable } from 'rxjs';
import { AppError } from '../app-errors/app-error';
import { NotFoundError } from '../app-errors/not-found-error';
import { BadInput } from '../app-errors/bad-input';
import { FlatModel } from '../models/flatModel';
import { UserModel } from '../models/UserModel';
import { Constants } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  headers = new HttpHeaders().set('content-type', 'application/json');

  constructor(
    private httpService: HttpClient) { }

  /**login user */
  login(url: string, user: UserModel){
    return this.httpService.post(url, user)
      .pipe(
        map((response:any)=>{
          let token = response.access_token;
          if(token){
            localStorage.setItem('access_token', token);
            return true;
          }
          else{
            return false;
          }
        }),
        catchError(this.handleError)
      )
  }
  /**logout user */
  logOut(){
    localStorage.removeItem("access_token");
  }

  /** register new user */
  registerUser(url: string, newUser: UserModel){
    return this.httpService.post<UserModel>(url, newUser, { headers: this.headers })
      .pipe(
        catchError(this.handleError)
      )
  }
/**chech the duplicate username */
IsUserNameExist(userName: string){
  return this.httpService.get(Constants.IsUserNameDuplicated + '/' + userName)
    .pipe(
      catchError(this.handleError)
    )
}
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
