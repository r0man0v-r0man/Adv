import { Injectable } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {DescriptionValidators} from '../../../validators/description.validators';
import {AuthService} from '../../../../../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RentFlatFormService {
  public form: FormGroup;
  constructor(
    private authService: AuthService,
    private fb: FormBuilder
  ) {
    this.form = this.fb.group({
      userId: [ this.authService.currentUser.sub, [Validators.required]],
      isActive: [ true ],
      images: [ null, [Validators.required]],
      address: this.fb.group({
        exactLocation: [ null, [Validators.required]],
        city: [ null, [Validators.required]]
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
  get isValid() {
    return this.form.valid;
  }
}
