import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { debounceTime, switchMap, map, distinctUntilChanged } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class SuggestService  {
  /** значение поля ввода адреса */
  searchChange$ = new BehaviorSubject('');
  /** статус поиска */
  isLoading = false;
  /** массив подсказок */
  suggestions: Array<{text: string; magicKey: string; isCollection: boolean}> = [];
  optionList$: Observable<Array<{text: string; magicKey: string; isCollection: boolean}>>;
  /** строка для запроса, text - параметр */
  urlBase: string = 'http://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/suggest?text='
  urlEnd: string = '&maxSuggestions=5&category=Address&countryCode=BLR&searchExtent=&location=&distance=&f=pjson'
  /** запрос на поиск адреса для подсказки */
  getSuggestList = (value: string) => this.http.get(`${this.urlBase}+${value}+${this.urlEnd}`).pipe(map((res: any) => { return res.suggestions }));
  constructor(
    private http: HttpClient) {
   }
   /** поиск подсказки */
   onSearch(value: string): void {
     if(value.length > 5){
      this.isLoading = true;
      this.searchChange$.next(value);
      this.optionList$ = this.searchChange$
      .asObservable()
      .pipe(debounceTime(1000),distinctUntilChanged())
      .pipe(switchMap(this.getSuggestList));
      this.optionList$.subscribe(data => {
        this.suggestions = data;
        this.isLoading = false;
      });
     }
  }
}
