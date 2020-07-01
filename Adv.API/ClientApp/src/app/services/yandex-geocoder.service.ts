import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, Subject} from 'rxjs';
import {debounceTime, distinctUntilChanged, filter, map, switchMap} from 'rxjs/operators';
import {FeatureMember, YandexResponseGeocoder} from '../models/yandex';

@Injectable()
export class YandexGeocoderService {
  url = 'https://geocode-maps.yandex.ru/1.x/';
  apiKey = '85e03f02-25be-40b3-971e-733f2a03e620';
  format = 'json';
  /** значение поля ввода адреса */
  searchChange$ = new Subject<string>();
  /** статус поиска */
  isLoading = false;
  optionList: FeatureMember[];
  constructor(
    private httpClient: HttpClient
  ) {
    const getList = (value: string) =>
      this.httpClient
        .get<YandexResponseGeocoder>(`${this.url}?apikey=${this.apiKey}&format=${this.format}&geocode=${value}`)
        .pipe(map((res) => res ));
    const optionList$: Observable<YandexResponseGeocoder> = this.searchChange$
      .asObservable()
      .pipe(debounceTime(1500), distinctUntilChanged())
      .pipe(filter( val => val.length > 5 ))
      .pipe(switchMap(getList));
    optionList$.subscribe(data => {
      this.optionList = data.response.GeoObjectCollection.featureMember;
      this.isLoading = false;
    });
  }
  onSearch(value: string) {
    this.isLoading = true;
    this.searchChange$.next(value);
  }
}
