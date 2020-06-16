import { Component, OnInit, Input } from '@angular/core';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { AdvertService } from 'src/app/services/advert.service';
import { FilterOptions } from 'src/app/models/filterOptions';
import { Router } from '@angular/router';
import { City } from 'src/app/models/city.model';

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
    private advertService: AdvertService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  showAdverts(city: City){
    
    this.advertService.getFlatRents(this.filterOption).subscribe(response => {
      if(response && response.length !== 0){
        this.listFlatRent = [...response];
        this.initLoading = false;
        // this.filterOption.pageNumber++;
        this.isShowMoreButton = true;
      }
      else{
        this.initLoading = false;
        this.isShowMoreButton = false;
      }
    })
  }
  onCardClick(advert: FlatRentModel){
      this.router.navigate(['flat', 'rent',advert.id], );
  }
}
