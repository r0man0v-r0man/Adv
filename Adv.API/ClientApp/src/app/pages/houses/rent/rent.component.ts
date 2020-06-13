import { Component, OnInit, Input } from '@angular/core';
import { HouseRentModel } from 'src/app/models/house-rent.model';
import { FilterOptions } from 'src/app/models/filterOptions';
import { Router } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'houses-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.less']
})
export class RentComponent implements OnInit {
  listHouseSale: HouseRentModel[] = [];
  @Input() filterOption: FilterOptions;
  initLoading: boolean = true;
  isShowMoreButton: boolean = true;
  constructor(
    private advertService: AdvertService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.initPage();    
  }

  initPage(){
    this.advertService.getHouseRents(this.filterOption).subscribe(response => {
      if(response && response.length !== 0){
        this.listHouseSale = [...response];
        this.initLoading = false;
        this.isShowMoreButton = true;
      }
      else{
        this.initLoading = false;
        this.isShowMoreButton = false;
      }
    })
  }
  onCardClick(advert: HouseRentModel){
      this.router.navigate(['house', 'rent', advert.id], );
  }

}
