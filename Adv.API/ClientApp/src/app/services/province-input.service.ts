import { Injectable } from '@angular/core';
import { IComponent } from '../models/yandex';
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
  optionList: IComponent[];
  constructor(
    private httpClient: HttpClient
  ) { 
    this.httpClient
      .get<IComponent[]>(`${Constants.getLocationsURL}`)
      .pipe(
        map((response: IComponent[]) => response)
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
