import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { SearchFlatCriteria } from 'src/app/models/searchFlatCriteria';
import { Router } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.less']
})
export class SearchResultComponent implements OnInit {
  list: FlatRentModel[] = [];
  searchParams: SearchFlatCriteria;
  initLoading = false; // bug
  /**Show or hide loadMore button */
  isShowMoreButton: boolean = false;
  pageNumber: number;
  constructor(
    private data: DataService,
    private advertService: AdvertService,
    private router: Router
    ) { }

  ngOnInit() {
    this.list = this.data.getSearchResult();
    this.searchParams = this.data.getSearchFields();
    this.searchParams.pageNumber++;
    this.isShowMoreButton = true;
  }
  onCardClick(flat: FlatRentModel){
    this.router.navigate(['flats/', flat.id]);
  }
  onLoadMore(){
    console.log(this.list.length);
    this.initLoading = true;
      this.advertService.findFlats(this.searchParams)
      .subscribe(response => {
        if(response && response.length > 0){
          for(var i = 0; i < response.length; i++){
            this.list.push(response[i]);
          }
          this.searchParams.pageNumber++;
        this.initLoading = false;
        }
        if(response && response.length === 0){
          this.isShowMoreButton = false;
        }
        this.initLoading = false;
      });
    
  }
}
