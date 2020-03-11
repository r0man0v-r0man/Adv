import { Injectable } from '@angular/core';
import { FlatModel } from '../models/flatModel';
import { SearchFlatCriteria } from '../models/searchFlatCriteria';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private searchFields: SearchFlatCriteria;
  private searchResult: FlatModel[] = [];
  constructor() { }
  setSearchFields(searchFields: SearchFlatCriteria){
    this.searchFields = searchFields;
  }

  getSearchFields(){
    let temp = this.searchFields;
    this.searchFields = undefined;
    return temp;
  }

  setSearchResult(result: FlatModel[]){
    this.searchResult = result;
  }
  getSearchResult(){
    let temp = this.searchResult;
    this.searchResult = undefined;
    return temp;
  }

}
