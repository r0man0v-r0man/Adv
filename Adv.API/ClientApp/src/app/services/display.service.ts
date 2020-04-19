import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DisplayService {
  isDisplayFooter: boolean = true;
  isDisplayNavBar: boolean = true;
  constructor() { }
  hideFooter(){
    this.isDisplayFooter = false;
  }
  hideNavBar(){
    this.isDisplayNavBar = false;
  }
}
