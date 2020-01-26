import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserModel } from '../models/UserModel';
import { map } from 'rxjs/operators';
import { Constants } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

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
     * get secure token
     */
  get SecureToken(){
    const token = localStorage.getItem('access_token');
    if(!token) return null;

    return this.headers.append("Authorization", 'Bearer ' + token);
  }
  /**
    * get current user
    */
  get currentUser(){
    const token = localStorage.getItem('access_token');
    if(!token) return null;

    return new JwtHelperService().decodeToken(token);
  }
}
