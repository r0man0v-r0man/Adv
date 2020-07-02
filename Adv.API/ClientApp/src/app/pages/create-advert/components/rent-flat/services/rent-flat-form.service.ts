import { Injectable } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {DescriptionValidators} from '../../../validators/description.validators';
import {AuthService} from '../../../../../services/auth.service';
import {Duration} from '../../../../../models/duration';

@Injectable()
export class RentFlatFormService {
  public form: FormGroup;
  /** тип аренды */
  listOfDuration: Array<{ label: string; value: number}> = [];
  /** балкон */
  listOfBalcony: Array<{ label: string, value: number }> = [];
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  constructor(
    private authService: AuthService,
    private fb: FormBuilder
  ) {
    this.initForm();
  }
  get isValid() {
    return this.form.valid;
  }
  /* Инициализация формы */
  private initForm() {
    this.setListOfBalcony();
    this.setDurations();
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
      balcony: [ null, [Validators.required]],
      furniture: [ null ],
      refrigerator: [ null],
      microwaveOven: [ null ],
      internet: [ null ],
      washingMachine: [ null ],
      price: [ null, [Validators.required]],
      duration: [ null , [Validators.required]],
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
  /** установка списка типов аренды */
  setDurations() {
    this.listOfDuration.push(
      { label: 'Длительная', value: Duration.long },
      { label: 'Часы/сутки', value: Duration.short }
    );
  }
}
