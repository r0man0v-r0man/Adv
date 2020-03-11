import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { FlatModel } from 'src/app/models/flatModel';
import { SearchFlatCriteria } from 'src/app/models/searchFlatCriteria';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.less']
})
export class SearchResultComponent implements OnInit {
  list: FlatModel[] = [];
  searchFields: SearchFlatCriteria;
  constructor(private data: DataService) { }

  ngOnInit() {
    this.list = this.data.getSearchResult();
    this.searchFields = this.data.getSearchFields();
  }

}
