import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserModel } from '../models/userModel';
import { map } from 'rxjs/operators';
import { Constants } from '../constants';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  headers = new HttpHeaders().set('content-type', 'application/json');
  private registerUrl: string = Constants.registerUser;
  private loginUrl: string = Constants.login;
  private isUserNameDublicatedUrl: string = Constants.IsUserNameDuplicated;
  constructor(
    private httpService: HttpClient
  ) { }
  /**login user */
  login(user: UserModel){
    return this.httpService.post(this.loginUrl, user)
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
  
    /** register new user */
    registerUser(newUser: UserModel){
      return this.httpService.post<boolean>(this.registerUrl, newUser, { headers: this.headers })
    }
    /**check the duplicate username */
    IsUserNameExist(userName: string){
      return this.httpService.get(this.isUserNameDublicatedUrl + '/' + userName)
    }
  get SecureHeaders(){
    const token = localStorage.getItem('access_token');
    if(!token) return null;

    return this.headers.append("Authorization", 'Bearer ' + token);
  }
  /** Is User Login */
  isLogedIn(){
    const jwtHelper = new JwtHelperService();
    let token = localStorage.getItem('access_token');
    
    if(!token) return false;

    const isExpired = jwtHelper.isTokenExpired(token);

    return !isExpired;
  }
  /**
    * текущий пользователь
    */
   get currentUser(){
    const token = localStorage.getItem('access_token');
    if(!token) return null;

    return new JwtHelperService().decodeToken(token);
  }
}
