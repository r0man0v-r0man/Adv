import { Injectable } from '@angular/core';
import { Component } from '../models/yandex';
import { Subject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants';
import { map, debounceTime, distinctUntilChanged, filter, switchMap } from 'rxjs/operators';

@Injectable()
export class ProvinceInputService {
  /** значение поля ввода адреса */
  searchChange$ = new Subject<string>();
  /** статус поиска */
  isLoading = true;
  optionList: Component[];
  constructor(
    private httpClient: HttpClient
  ) { 
    this.httpClient
      .get<Component[]>(`${Constants.getLocationsURL}`)
      .pipe(
        map((response: Component[]) => response)
      ).subscribe(data => {
      this.optionList = data;
      this.isLoading = false;
    })
  }
  onSearch(value: string) {
    this.isLoading = true;
    this.searchChange$.next(value);
  }
}
