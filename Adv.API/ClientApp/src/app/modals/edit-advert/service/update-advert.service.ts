import { Injectable } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DescriptionValidators } from 'src/app/pages/create-advert/validators/description.validators';

@Injectable()
export class UpdateAdvertService {
  form: FormGroup;
  constructor(
    private fb: FormBuilder
  ) { 
    this.initForm();
  }
  initForm() {
    this.form = this.fb.group({
      price: [ '', [Validators.required]],
      phone: [ null, [Validators.required, Validators.pattern('[0-9]*')]],
      description: [ null, [DescriptionValidators.notOnlySpace]]
    })
  }
}
