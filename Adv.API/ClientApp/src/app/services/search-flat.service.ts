import { Injectable, Injector } from '@angular/core';
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
  /** for SSR */
  private baseUrl: string;
  constructor(
    private httpService: HttpClient,
    private authService: AuthService,
    private injector: Injector
  ) { 
    this.baseUrl = this.injector.get('BASE_URL');
  }

  findFlats(criteria: SearchFlatCriteria){
    return this.httpService.post<FlatModel[]>(`${this.baseUrl}${this.searchFlatUrl}`, criteria, { headers: this.authService.headers});
  }

}
