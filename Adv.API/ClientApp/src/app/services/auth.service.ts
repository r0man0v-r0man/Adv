import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserModel } from '../models/userModel';
import { map } from 'rxjs/operators';
import { Constants } from '../constants';
import { Observable } from 'rxjs';
import { LOCAL_STORAGE } from '@ng-toolkit/universal'
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  headers = new HttpHeaders().set('content-type', 'application/json');
  private registerUrl: string = Constants.registerUser;
  private loginUrl: string = Constants.login;
  private isUserNameDublicatedUrl: string = Constants.IsUserNameDuplicated;
  constructor(
    private httpService: HttpClient,
    @Inject(LOCAL_STORAGE) private localStorage: any
  ) { }
  /**login user */
  login(user: UserModel){
    return this.httpService.post(this.loginUrl, user)
      .pipe(
        map((response:any)=>{
          let token = response.access_token;
          if(token){
            this.localStorage.setItem('access_token', token);
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
    /** get JWT token for upload image */
  get Token(){
    const token = localStorage.getItem('access_token');
    if(!token) return null;
    const XCMG = `Bearer ${token}`;
    return {
      Authorization: XCMG
    }
  }
  get SecureHeaders(){
    const token = this.localStorage.getItem('access_token');
    if(!token) return null;

    return this.headers.append("Authorization", 'Bearer ' + token);
  }
  /** Is User Login */
  isLogedIn(): Observable<boolean>{
    return new Observable<boolean>(observer => {
      const jwtHelper = new JwtHelperService();
      let token = this.localStorage.getItem('access_token');
      
      if(!token) return observer.next(false);

      const isExpired = jwtHelper.isTokenExpired(token);
  
      return observer.next(!isExpired);
    })
 
  }
  /**
    * текущий пользователь
    */
   get currentUser(){
    const token = this.localStorage.getItem('access_token');
    if(!token) return null;

    return new JwtHelperService().decodeToken(token);
  }
      /**logout user */
      logOut(){
        this.localStorage.removeItem("access_token");
      }
}
