import { Component, OnInit } from '@angular/core';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { AdvertService } from 'src/app/services/advert.service';
import { FilterOptions } from 'src/app/models/filterOptions';

@Component({
  selector: 'flats-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.less']
})
export class RentComponent implements OnInit {

  list: FlatRentModel[] = [];

  constructor(
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    let options: FilterOptions = {
      pageNumber: 1
    }
    this.advertService.getFlatRents(options).subscribe(response => {
      console.log(response);
    })
  }

}
