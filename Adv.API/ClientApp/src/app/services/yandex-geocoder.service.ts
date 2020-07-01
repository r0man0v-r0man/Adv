import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {debounceTime, distinctUntilChanged, filter, map, switchMap} from 'rxjs/operators';
import {YandexResponseGeocoder} from '../models/yandex';

@Injectable()
export class YandexGeocoderService {
  url = 'https://geocode-maps.yandex.ru/1.x/';
  apiKey = '85e03f02-25be-40b3-971e-733f2a03e620';
  format = 'json';
  /** значение поля ввода адреса */
  searchChange$ = new BehaviorSubject('');
  /** статус поиска */
  isLoading = false;
  optionList: any;
  constructor(
    private httpClient: HttpClient
  ) {
    const getList = (value: string) =>
      this.httpClient
        .get(`${this.url}?apikey=${this.apiKey}&format=${this.format}&geocode=${value}`)
        .pipe(map((res) => res ));
    const optionList$: Observable<any> = this.searchChange$
      .asObservable()
      .pipe(debounceTime(1000), distinctUntilChanged())
      .pipe(filter( val => val.length > 5 ))
      .pipe(switchMap(getList));
    optionList$.subscribe(data => {
      console.log(data);
      this.optionList = data.response.GeoObjectCollection.featureMember;
      console.log(this.optionList);
      const mod: YandexResponseGeocoder = data;
      console.log('yandex: ', mod.response.GeoObjectCollection.featureMember[0].GeoObject.metaDataProperty.GeocoderMetaData.Address.Components);
      this.isLoading = false;
    });
  }
  onSearch(value: string) {
    this.isLoading = true;
    this.searchChange$.next(value);
  }
}
