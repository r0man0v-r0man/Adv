import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterService extends DataService {

  constructor(httpService: HttpClient) { 
    super(httpService);
  }
}
