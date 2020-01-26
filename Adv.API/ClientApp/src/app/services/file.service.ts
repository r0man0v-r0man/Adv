import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(
    private httpService: HttpClient,
    private authService: AuthService
    ) {
   }
   
   deleteFile(url: string, fileName: string){
    return this.httpService.delete<boolean>(url + '/' + fileName, { headers: this.authService.SecureToken })
  }
}