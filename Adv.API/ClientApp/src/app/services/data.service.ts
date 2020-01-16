import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators'
import { FlatModel } from '../models/flatModel';
import { UserModel } from '../models/UserModel';
import { Constants } from '../constants';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  headers = new HttpHeaders().set('content-type', 'application/json');

  constructor(
    private httpService: HttpClient
    ) { }

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
        })
      )
  }
  /**logout user */
  logOut(){
    localStorage.removeItem("access_token");
  }
  /** Is User Login */
  isLogedIn(){
    const jwtHelper = new JwtHelperService();
    let token = localStorage.getItem('access_token');
    
    if(!token) return false;

    const isExpired = jwtHelper.isTokenExpired(token);

    return !isExpired;
  }

  /** register new user */
  registerUser(url: string, newUser: UserModel){
    return this.httpService.post<boolean>(url, newUser, { headers: this.headers })
  }
  /**check the duplicate username */
  IsUserNameExist(userName: string){
    return this.httpService.get(Constants.IsUserNameDuplicated + '/' + userName)
  }
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
  deleteFile(url: string, fileName: string){
    return this.httpService.delete<boolean>(url + '/' + fileName)
  }

}
