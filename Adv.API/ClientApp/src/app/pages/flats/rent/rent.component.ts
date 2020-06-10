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

  listFlatRent: FlatRentModel[] = [];
  filterOption: FilterOptions;
  initLoading: boolean = true;
  isShowMoreButton: boolean = true;
  constructor(
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.initPage();
  }
  private setFilterOption(): FilterOptions {
    return {
      pageNumber: 1
    };
  }

  initPage(){
    this.filterOption = this.setFilterOption();
    this.advertService.getFlatRents(this.filterOption).subscribe(response => {
      if(response && response.length !== 0){
        this.listFlatRent = [...response];
        this.initLoading = false;
        this.filterOption.pageNumber++;
        this.isShowMoreButton = true;
      }
      else{
        this.initLoading = false;
        this.isShowMoreButton = false;
      }
    })
  }
}
