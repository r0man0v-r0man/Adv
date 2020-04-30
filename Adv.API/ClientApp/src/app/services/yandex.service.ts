import { Injectable } from '@angular/core';
import ymaps from 'ymaps';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class YandexService {
  isLoading: boolean;
  listOfAddresses$ = new BehaviorSubject<Array<{ displayName: string; value: string }>>([]);
  constructor() { }
  getSuggests(value: string) {
    console.log(value);
      ymaps.load("https://api-maps.yandex.ru/2.1/?apikey=85e03f02-25be-40b3-971e-733f2a03e620&lang=ru_RU")
        .then(maps => {
          maps.suggest(value, {
            results: 10
            })
        .then(items => {
          
          const list: Array<{ displayName: string; value: string }> = [];
          items.forEach(suggest => {
            list.push({
              displayName: suggest.displayName,
              value: suggest.value
            })
          });
          this.listOfAddresses$.next(items);
            this.isLoading = true;
            
        })
      })
    this.isLoading = false;

  }
}
