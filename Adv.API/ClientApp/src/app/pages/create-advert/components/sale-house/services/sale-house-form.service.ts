import { Injectable } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../../../../services/auth.service';
import {DescriptionValidators} from '../../../validators/description.validators';

@Injectable()
export class SaleHouseFormService {
  form: FormGroup;
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
      isActive: [ false ],
      images: [ null, [Validators.required]],
      address:  [ null, [Validators.required]],
      houseArea: [ null, [Validators.required]],
      houseLiveArea: [ null, [Validators.required]],
      kitchenArea: [ null, [Validators.required]],
      housePlotArea: [ null, [Validators.required]],
      heating: [ false ],
      water: [ false ],
      gas: [ false ],
      sewage: [ false ],
      electricity: [ false ],
      bathhouse: [ false ],
      garage: [ false ],
      price: [ '', [Validators.required]],
      phone: [ null, [Validators.required, Validators.pattern('[0-9]*')]],
      description: [ null, [DescriptionValidators.notOnlySpace]]
    });
  }
}
