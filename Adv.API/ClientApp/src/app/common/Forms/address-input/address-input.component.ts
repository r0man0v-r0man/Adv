import {Component, forwardRef} from '@angular/core';
import {ControlValueAccessor, NG_VALUE_ACCESSOR} from '@angular/forms';
import {YandexGeocoderService} from '../../../services/yandex-geocoder.service';

@Component({
  selector: 'app-address-input',
  templateUrl: './address-input.component.html',
  styleUrls: ['./address-input.component.less'],
  providers: [
    YandexGeocoderService,
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => AddressInputComponent),
      multi: true
    }
  ]
})
export class AddressInputComponent implements ControlValueAccessor {
  inputValue = null;
  constructor(
    public yandexGeocoderService: YandexGeocoderService
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
  onSelectionChange() {
    this.onChange(this.inputValue);
  }
}
