import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AdvertService } from 'src/app/services/advert.service';
import { ImageService } from 'src/app/services/image.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import {RentFlatFormService} from './services/rent-flat-form.service';

@Component({
  selector: 'app-rent-flat',
  templateUrl: './rent-flat.component.html',
  styleUrls: ['./rent-flat.component.less'],
  providers: [
    RentFlatFormService
  ]
})
export class RentFlatComponent implements OnInit {

  get form(): FormGroup {
    return this.rentFlatFormService.form;
  }
  get isValid() {
    return this.rentFlatFormService.isValid;
  }
  get listOfBalcony() {
    return this.rentFlatFormService.listOfBalcony;
  }
  get listOfDuration() {
    return this.rentFlatFormService.listOfDuration;
  }
  get formatter() {
    return this.rentFlatFormService.formatterDollar;
  }
  get parser() {
    return this.rentFlatFormService.parserDollar;
  }
  constructor(
    private rentFlatFormService: RentFlatFormService,
    private advertService: AdvertService,
    public imageService: ImageService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
  }

  /** создание объявления */
  submitForm() {
    const rentFlatModel: FlatRentModel = { ...this.form.value };
    this.advertService.addFlatRent(this.form.value);
  }
  
  /**
   * установка значения для поля формы
   * @param formControlName имя поля
   * @param value значение
   */
  private setRentFlatFormControlValue(formControlName: string, value: any) {
    this.form.controls[formControlName].setValue(value);
  }
}
