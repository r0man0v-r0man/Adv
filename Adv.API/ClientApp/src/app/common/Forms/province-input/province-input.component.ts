import { Component, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { switchMap, debounceTime, map } from 'rxjs/operators';

@Component({
  selector: 'app-province-input',
  templateUrl: './province-input.component.html',
  styleUrls: ['./province-input.component.less'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ProvinceInputComponent),
      multi: true
    }
  ]
})
export class ProvinceInputComponent implements ControlValueAccessor {
  inputValue = null;
  randomUserUrl = 'https://api.randomuser.me/?results=5';
  searchChange$ = new BehaviorSubject('');
  optionList: string[] = [];
  selectedUser?: string;
  isLoading = false;
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    // tslint:disable:no-any
    const getRandomNameList = (name: string) =>
      this.http
        .get(`${this.randomUserUrl}`)
        .pipe(map((res: any) => res.results))
        .pipe(
          map((list: any) => {
            return list.map((item: any) => `${item.name.first} ${name}`);
          })
        );
    const optionList$: Observable<string[]> = this.searchChange$
      .asObservable()
      .pipe(debounceTime(500))
      .pipe(switchMap(getRandomNameList));
    optionList$.subscribe(data => {
      this.optionList = data;
      this.isLoading = false;
    });
  }
  onChange: any = () => {};
  onTouched: any = () => {};
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
  writeValue(input: string): void {
    this.inputValue = input;
  }

  onSearch(value: string): void {
    this.isLoading = true;
    this.searchChange$.next(value);
  }
  onSelectionChange() {
    this.onChange(this.inputValue);
  }
}
