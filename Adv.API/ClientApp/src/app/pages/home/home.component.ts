import { Component, OnInit } from '@angular/core';
import { TypeOfAdvert } from 'src/app/models/advertType';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {
  
  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
  }
  onCardClick(adverts: string) {
    this.router.navigate([adverts]);
  }
}
