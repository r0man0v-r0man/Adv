import { Component, OnInit } from '@angular/core';
import { DisplayService } from './services/display.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  linkedInUrl: string = 'https://www.linkedin.com/in/roman-romanov-276b0417a';
  isShowFooter: boolean;
  isShowNavBar: boolean;
  constructor(
    private displayService: DisplayService
  ) { }
  ngOnInit() {
    this.isShowFooter = this.displayService.isDisplayFooter;
    this.isShowNavBar = this.displayService.isDisplayNavBar;
  }
}
