import { Injectable, ChangeDetectorRef } from '@angular/core';
import ymaps from 'ymaps';
import { BehaviorSubject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class YandexService {
  nzFilterOption = () => true;
  isOpen: boolean = false;
  isHide: boolean = false;
  listOfAddresses$ = new BehaviorSubject<Array<{ displayName: string; value: string }>>([]);
  suggestView;
  constructor(
  ) { }
  onBlur(event){
    console.log('onblur -> ', event);
    
  }
  onFocus(event){
    console.log('onFocus -> ', event);
    
  }
  onOpenChange(value){
    console.log('onOpenChange -> ', value);
    
  }
  getSuggests(value: string) {
      console.log(value);
      ymaps.load("https://api-maps.yandex.ru/2.1/?apikey=85e03f02-25be-40b3-971e-733f2a03e620&lang=ru_RU")
        .then(maps => {
          maps.suggest(value, {
            results: 10
            })
        .then(items => {
          if(items && items.length > 0){
            const list: Array<{ displayName: string; value: string }> = [];
            items.forEach(suggest => {
              list.push({
                displayName: suggest.displayName,
                value: suggest.value
              })
            });
            this.listOfAddresses$.next(items);
          }
        })
      })
  }
}
