import { Component, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { switchMap, debounceTime, map, distinctUntilChanged } from 'rxjs/operators';
import { Constants } from 'src/app/constants';

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
  searchChange$ = new BehaviorSubject('');
  optionList: string[] = [];
  selectedUser?: string;
  isLoading = false;
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    const getRandomNameList = (name: string) =>
      this.http.get<string[]>(`${Constants.getProvinceURL}`)
        .pipe(map((response: string[]) => response));
    const optionList$: Observable<string[]> = this.searchChange$
      .asObservable()
      .pipe(debounceTime(1500),distinctUntilChanged())
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
