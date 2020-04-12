import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Constants } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  deleteFileUrl: string = Constants.deleteFileUrl;

  constructor(
    private httpService: HttpClient,
    private authService: AuthService
    ) {
   }
   
   deleteFile(fileName: string){
    return this.httpService.delete<boolean>(this.deleteFileUrl + '/' + fileName, { headers: this.authService.SecureHeaders })
  }
  
}