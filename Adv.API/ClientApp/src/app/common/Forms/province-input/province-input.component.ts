import { Component, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { switchMap, debounceTime, map, distinctUntilChanged } from 'rxjs/operators';
import { Constants } from 'src/app/constants';
import { ProvinceInputService } from 'src/app/services/province-input.service';

@Component({
  selector: 'app-province-input',
  templateUrl: './province-input.component.html',
  styleUrls: ['./province-input.component.less'],
  providers: [
    ProvinceInputService,
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ProvinceInputComponent),
      multi: true
    }
  ]
})
export class ProvinceInputComponent implements ControlValueAccessor {
  inputValue = null;
  constructor(
    public provinceInputService: ProvinceInputService
  ) {}

  ngOnInit(): void {
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
  onSelectionChange() {
    this.onChange(this.inputValue);
  }
}
