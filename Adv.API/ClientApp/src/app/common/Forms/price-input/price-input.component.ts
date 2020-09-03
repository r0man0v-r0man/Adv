import { Component, forwardRef } from '@angular/core';
import { PriceService } from 'src/app/services/price.service';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';

@Component({
  selector: 'app-price-input',
  templateUrl: './price-input.component.html',
  styleUrls: ['./price-input.component.less'],
  providers: [
    PriceService,
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => PriceInputComponent),
      multi: true
    }
  ]
})
export class PriceInputComponent implements ControlValueAccessor {
  inputValue = null;
  constructor(
    private priceService: PriceService
  ) { }
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
  onPriceChange() {
    this.onChange(this.inputValue);
  }
  get formatter() {
    return this.priceService.formatterDollar;
  }
  get parser() {
    return this.priceService.parserDollar;
  }
}
