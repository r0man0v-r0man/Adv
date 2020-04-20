import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  headers = new HttpHeaders().set('content-type', 'application/json');
  constructor(
    private httpService: HttpClient
  ) { }
  get SecureHeaders(){
    const token = localStorage.getItem('access_token');
    if(!token) return null;

    return this.headers.append("Authorization", 'Bearer ' + token);
  }
}
