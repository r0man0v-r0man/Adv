import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.less']
})
export class FooterComponent implements OnInit {
  linkedInUrl: string = 'https://www.linkedin.com/in/roman-romanov-276b0417a/'
  constructor() { }

  ngOnInit() {
  }

}
