import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { FlatModel } from 'src/app/models/flatModel';
import { SearchFlatCriteria } from 'src/app/models/searchFlatCriteria';
import { FlatService } from 'src/app/services/flat.service';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.less']
})
export class SearchResultComponent implements OnInit {
  list: FlatModel[] = [];
  searchFields: SearchFlatCriteria;
  initLoading = false; // bug
  /**Show or hide loadMore button */
  isShowMoreButton: boolean = false;
  pageNumber: number;
  constructor(
    private data: DataService,
    private flatService: FlatService
    ) { }

  ngOnInit() {
    this.list = this.data.getSearchResult();
    this.searchFields = this.data.getSearchFields();
    this.pageNumber = this.searchFields.pageNumber;
    this.isShowMoreButton = true;

  }
  onLoadMore(){
    this.initLoading = true;

      this.flatService.getFlats(this.pageNumber)
      .subscribe(response => {
        if(response && response.length > 0){
          for(var i = 0; i < response.length; i++){
            this.list.push(response[i]);
          }
          this.pageNumber++;
        this.initLoading = false;

        }
        if(response && response.length === 0){
          this.isShowMoreButton = false;
        }
        this.initLoading = false;

      });
    
  }
}
