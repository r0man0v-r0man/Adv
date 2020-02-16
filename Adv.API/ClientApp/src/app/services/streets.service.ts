import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StreetsService {

  constructor(private http: HttpClient) { }
  getStreets(){
    return this.http.get<{ name: string, streets:Array<{name:string}> }>('assets/streets.json');
  }
}
