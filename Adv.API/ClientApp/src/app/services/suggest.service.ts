import { Injectable, Injector, Inject } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { debounceTime, switchMap, map, distinctUntilChanged, filter } from 'rxjs/operators';
import { Constants } from '../constants';
import { LOCAL_STORAGE } from '@ng-toolkit/universal';
import { City } from '../models/city.model';

@Injectable({
  providedIn: 'root'
})

export class SuggestService  {
    /** for SSR */
    private baseUrl: string;
    /** Array of cities */
listOfCities: City[] = [];
  /** значение поля ввода адреса */
  searchChange$ = new Subject<string>();
  /** статус поиска */
  isLoading = false;
  /** массив подсказок */
  suggestions: Array<{text: string; magicKey: string; isCollection: boolean}> = [];
  private optionList$: Observable<Array<{text: string; magicKey: string; isCollection: boolean}>>;
  /** строка для запроса, text - параметр */
  private urlBase = 'https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/suggest?text=';
  private urlEnd = '&maxSuggestions=5&category=Address&countryCode=BLR&searchExtent=&location=&distance=&f=pjson';
  /** запрос на поиск адреса для подсказки */
  private getSuggestList = (value: string) => this.http.get(`${this.urlBase}+${value}+${this.urlEnd}`)
    .pipe(map((res: any) => res.suggestions ))
  constructor(
    private http: HttpClient,
    private injector: Injector,
    @Inject(LOCAL_STORAGE) private localStorage: any
    ) {
      this.getSuggests();
      this.baseUrl = this.injector.get('BASE_URL');
      this.getCities();
    }
  /** поиск подсказок */
  private getSuggests() {
    this.isLoading = true;
    this.optionList$ = this.searchChange$
    .pipe(debounceTime(1000), distinctUntilChanged())
    .pipe(filter( val => val.length > 5 ))
    .pipe(switchMap(this.getSuggestList));
    this.optionList$.subscribe(data => {
      this.suggestions = data;
      this.isLoading = false;
    });
  }

  getCities() {
    this.http.get<City[]>(`${this.baseUrl}${Constants.getCitiesURL}`).subscribe(response => {
      if (response) {
        this.listOfCities = [...response];
      }
    });
  }

}
