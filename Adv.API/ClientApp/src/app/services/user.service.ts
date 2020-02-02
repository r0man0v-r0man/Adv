import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants';
import { UserModel } from '../models/UserModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  userInfoUrl = Constants.getUserInfo;
  constructor(
    private httpService: HttpClient,
    private authService: AuthService
  ) { }

  getUserInfo(userId: string){
    return this.httpService.get<UserModel>(
      this.userInfoUrl + '/' + userId, 
      { 
        headers: this.authService.SecureHeaders 
      }
    );
  }
}
