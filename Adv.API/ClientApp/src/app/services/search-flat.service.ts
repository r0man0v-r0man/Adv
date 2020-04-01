import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants';
import { SearchFlatCriteria } from '../models/searchFlatCriteria';
import { FlatModel } from '../models/flatModel';

@Injectable({
  providedIn: 'root'
})
export class SearchFlatService {
  private searchFlatUrl: string = Constants.searchFlat;
  constructor(
    private httpService: HttpClient,
    private authService: AuthService
  ) { }

  findFlats(criteria: SearchFlatCriteria){
    return this.httpService.post<FlatModel[]>(this.searchFlatUrl, criteria, { headers: this.authService.headers});
  }

}
