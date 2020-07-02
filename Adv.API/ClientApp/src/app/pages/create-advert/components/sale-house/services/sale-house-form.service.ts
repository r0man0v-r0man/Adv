import { Injectable } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../../../../services/auth.service';
import {DescriptionValidators} from '../../../validators/description.validators';

@Injectable()
export class SaleHouseFormService {
  form: FormGroup;
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
    this.form = this.fb.group({
      userId: [ this.authService.currentUser.sub, [Validators.required]],
      isActive: [ true ],
      images: [ null, [Validators.required]],
      address: this.fb.group({
        geoObject: [ null, [Validators.required]]
      }),
      houseArea: [ null, [Validators.required]],
      houseLiveArea: [ null, [Validators.required]],
      kitchenArea: [ null, [Validators.required]],
      housePlotArea: [ null, [Validators.required]],
      heating: [ null ],
      water: [ null ],
      gas: [ null ],
      sewage: [ null ],
      electricity: [ null ],
      bathhouse: [ null ],
      garage: [ null ],
      price: [ null, [Validators.required]],
      phone: [ null, [Validators.required, Validators.pattern('[0-9]*')]],
      description: [ null, [DescriptionValidators.notOnlySpace]]
    });
  }
}
