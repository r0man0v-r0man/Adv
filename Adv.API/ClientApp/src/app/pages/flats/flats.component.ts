import { Component, OnInit } from '@angular/core';
import { FilterOptions } from 'src/app/models/filterOptions';

@Component({
  selector: 'app-flats',
  templateUrl: './flats.component.html',
  styleUrls: ['./flats.component.less']
})
export class FlatsComponent implements OnInit {

  isShowFlatRents: boolean = false;
  isShowFlatSales: boolean = false;

  filterOption: FilterOptions;

  constructor() { }

  ngOnInit(): void {
    this.filterOption = this.setFilterOption();
    this.isShowFlatRents = true;
  }

  private setFilterOption(): FilterOptions {
    return {
      pageNumber: 1
    };
  }
}
