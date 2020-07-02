import { Injectable } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {AuthService} from '../../../../../services/auth.service';

@Injectable()
export class RentHouseFormService {
  /* Форма */
  public form: FormGroup;
  constructor(
    private fb: FormBuilder,
    private authService: AuthService
  ) {

  }
}
