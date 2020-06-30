import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {GeocoderMetaData, GeoObjectCollection} from '../models/yandex';
import {Observable, Subject} from 'rxjs';
import {debounceTime, distinctUntilChanged, filter, map, switchMap} from 'rxjs/operators';

@Injectable()
export class YandexGeocoderService {
  url = 'https://geocode-maps.yandex.ru/1.x/';
  apiKey = '85e03f02-25be-40b3-971e-733f2a03e620';
  /** значение поля ввода адреса */
  searchChange$ = new Subject<string>();
  private optionList$: Observable<GeoObjectCollection>;
  format = 'json';
  /** статус поиска */
  isLoading = false;
  listOfSuggestions: GeocoderMetaData[] = [];
  /** запрос на поиск адреса для подсказки */
  private getSuggestList = (value: string) => this.httpClient.get<GeoObjectCollection>(
    `${this.url}?apikey=${this.apiKey}&format=${this.format}&geocode=${value}`
  ).pipe(
    map((response) => response )
  )
  constructor(
    private httpClient: HttpClient
  ) {
    this.getSuggests();
  }
  /** поиск подсказок */
  private getSuggests() {
    this.isLoading = true;
    this.optionList$ = this.searchChange$
      .pipe(debounceTime(1000), distinctUntilChanged())
      .pipe(filter( val => val.length > 5 ))
      .pipe(switchMap(this.getSuggestList));
    this.optionList$.subscribe(data => {
      const list: GeocoderMetaData[] = [];
      data.featureMember.forEach((geo) => {
        list.push(geo.metaDataProperty);
      });
      this.listOfSuggestions = list;
      this.isLoading = false;
    });
  }
}
