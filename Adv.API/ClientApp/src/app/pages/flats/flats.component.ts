import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-flats',
  templateUrl: './flats.component.html',
  styleUrls: ['./flats.component.less']
})
export class FlatsComponent implements OnInit {

  isShowFlatRents: boolean = false;
  isShowFlatSales: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
