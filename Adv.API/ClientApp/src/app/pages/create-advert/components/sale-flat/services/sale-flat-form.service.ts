import { Injectable } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../../../../services/auth.service';
import {DescriptionValidators} from '../../../validators/description.validators';

@Injectable()
export class SaleFlatFormService {
  form: FormGroup;
  /** туалет */
  listOfToilet: Array<{ label: string; value: number}> = [];
  /** балкон */
  listOfBalcony: Array<{ label: string, value: number }> = [];
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  constructor(
    private fb: FormBuilder,
    private authService: AuthService
  ) {
    this.initForm();
  }
  get isValid() {
    return this.form.valid;
  }
  /* инициализация формы */
  initForm() {
    this.setListOfBalcony();
    this.setListOfToilet();
    this.form = this.fb.group({
      userId: [ this.authService.currentUser.sub, [Validators.required]],
      isActive: [ true ],
      images: [ null, [Validators.required]],
      address: this.fb.group({
        geoObject: [ null, [Validators.required]]
      }),
      floor: [ null, [Validators.required]],
      allFloor: [ null, [Validators.required]],
      rooms: [ null, [Validators.required]],
      flatArea: [ null, [Validators.required]],
      flatLiveArea: [ null, [Validators.required]],
      kitchenArea: [ null, [Validators.required]],
      balcony: [ null, [Validators.required]],
      toilet: [ null, [Validators.required]],
      price: [ null, [Validators.required]],
      phone: [ null, [Validators.required, Validators.pattern('[0-9]*')]],
      description: [ null, [DescriptionValidators.notOnlySpace]]
    });
  }
  /** установка наличия балкона */
  setListOfBalcony() {
    this.listOfBalcony.push(
      { label: 'Есть', value: 1 },
      { label: 'Нет', value: 0 }
    );
  }
  setListOfToilet() {
    this.listOfToilet.push(
      { label: 'Раздельный', value: 0 },
      { label: 'Совмещенный', value: 1 }
    );
  }
}
