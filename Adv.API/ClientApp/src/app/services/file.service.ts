import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(
    private httpService: HttpClient) {
   }
   
   deleteFile(url: string, fileName: string){
    return this.httpService.delete<boolean>(url + '/' + fileName)
  }
}