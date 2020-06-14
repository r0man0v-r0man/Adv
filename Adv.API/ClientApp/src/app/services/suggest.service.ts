import { Injectable, Injector, Inject } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { debounceTime, switchMap, map, distinctUntilChanged, filter } from 'rxjs/operators';
import { Constants } from '../constants';
import { LOCAL_STORAGE } from '@ng-toolkit/universal'

@Injectable({
  providedIn: 'root'
})

export class SuggestService  {
    /** for SSR */
    private baseUrl: string;
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
    private http: HttpClient,
    private injector: Injector,
    @Inject(LOCAL_STORAGE) private localStorage: any
    ) { 
      this.getSuggests();
      this.baseUrl = this.injector.get('BASE_URL');
    }
  /** поиск подсказок */  
  private getSuggests(){
    this.isLoading = true;
    this.optionList$ = this.searchChange$
    .pipe(debounceTime(1000),distinctUntilChanged())
    .pipe(filter( val => val.length > 5 ))
    .pipe(switchMap(this.getSuggestList));
    this.optionList$.subscribe(data => {
      this.suggestions = data;
      this.isLoading = false;
    });
  }

  getCities(){
    return this.http.get<[]>(`${this.baseUrl}${Constants.getCitiesURL}`);
  }

}
