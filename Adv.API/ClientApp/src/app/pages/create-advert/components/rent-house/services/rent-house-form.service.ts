import { Injectable } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../../../../services/auth.service';
import {DescriptionValidators} from '../../../validators/description.validators';
import {Duration} from '../../../../../models/duration';

@Injectable()
export class RentHouseFormService {
  /* Форма */
  public form: FormGroup;
  /** тип аренды */
  listOfDuration: Array<{ label: string; value: number}> = [];
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  get isValid() {
    return this.form.valid;
  }
  constructor(
    private fb: FormBuilder,
    private authService: AuthService
  ) {
    this.initForm();
  }
  /* инициализация формы */
  initForm() {
    this.setDurations();
    this.form = this.fb.group({
      userId: [ this.authService.currentUser.sub, [Validators.required]],
      isActive: [ true ],
      images: [ null, [Validators.required]],
      address:  [ null, [Validators.required]],
      rooms: [ null ],
      furniture: [ null ],
      refrigerator: [ null ],
      microwaveOven: [ null ],
      internet: [ null ],
      washingMachine: [ null ],
      bathhouse: [ null ],
      garage: [ null ],
      price: [ null, [Validators.required]],
      duration: [ null, [Validators.required]],
      phone: [ null, [Validators.required, Validators.pattern('[0-9]*')]],
      description: [ null, [DescriptionValidators.notOnlySpace]]
    });
  }
  /** установка списка типов аренды */
  setDurations() {
    this.listOfDuration.push(
      { label: 'Длительная', value: Duration.long },
      { label: 'Часы/сутки', value: Duration.short }
    );
  }
}
