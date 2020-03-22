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
    localStorage.setItem('searchFields', JSON.stringify(searchFields));
  }
  getSearchFields(){
    return JSON.parse(localStorage.getItem('searchFields'));
  }
  setSearchResult(result: FlatModel[]){
    localStorage.setItem('searchResult', JSON.stringify(result));
  }
  getSearchResult(){
    return JSON.parse(localStorage.getItem('searchResult'));
  }

}
