import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { debounceTime, switchMap, map, distinctUntilChanged } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class SuggestService  {
  /** значение поля ввода адреса */
  searchChange$ = new Subject<string>();
  /** статус поиска */
  isLoading = false;
  /** массив подсказок */
  suggestions: Array<{text: string; magicKey: string; isCollection: boolean}> = [];
  private optionList$: Observable<Array<{text: string; magicKey: string; isCollection: boolean}>>;
  /** строка для запроса, text - параметр */
  private urlBase: string = 'http://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/suggest?text='
  private urlEnd: string = '&maxSuggestions=5&category=Address&countryCode=BLR&searchExtent=&location=&distance=&f=pjson'
  /** запрос на поиск адреса для подсказки */
  private getSuggestList = (value: string) => this.http.get(`${this.urlBase}+${value}+${this.urlEnd}`).pipe(map((res: any) => { return res.suggestions }));
  constructor(
    private http: HttpClient
    ) { 
      this.getSuggests();
    }
  /** поиск подсказок */  
  private getSuggests(){
    this.isLoading = true;
    this.optionList$ = this.searchChange$
    .pipe(debounceTime(1000),distinctUntilChanged())
    .pipe(switchMap(this.getSuggestList));
    this.optionList$.subscribe(data => {
      this.suggestions = data;
      this.isLoading = false;
    });
  }
}
