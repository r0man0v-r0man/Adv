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
  isLoading = false;
  optionList: Component[];
  constructor(
    private httpClient: HttpClient
  ) { 
    const getList = (value: string) => this.httpClient
      .get<Component[]>(`${Constants.getLocationsURL}/${value}`)
      .pipe(
        map((response: Component[]) => response)
      );
    const optionList$: Observable<Component[]> = this.searchChange$
      .asObservable()
      .pipe(debounceTime(1500), distinctUntilChanged())
      .pipe(filter( val => val.length > 5 ))
      .pipe(switchMap(getList));
    optionList$.subscribe(data => {
      this.optionList = data;
      this.isLoading = false;
    })
  }
  onSearch(value: string) {
    this.isLoading = true;
    this.searchChange$.next(value);
  }
}
