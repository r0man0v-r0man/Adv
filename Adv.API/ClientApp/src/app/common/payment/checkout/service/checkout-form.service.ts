import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PaymentRequestOptions, StripeCardElementOptions } from '@stripe/stripe-js';
import { AuthService } from 'src/app/services/auth.service';

@Injectable()
export class CheckoutFormService {
  form: FormGroup;
  constructor(
    private fb: FormBuilder,
    private authService: AuthService
  ) { 
    this.initForm();
  }
  initForm() {
    this.form = this.fb.group({
      name: [ this.authService.currentUser.sub, [Validators.required]]
    });
  }
  initCardOptions(): StripeCardElementOptions {
    return {
      hidePostalCode: true,
      style: {
        base: {
          lineHeight: '1.5715',
          iconColor: '#666EE8',
          color: '#31325F',
          fontWeight: '300',
          fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
          fontSize: '18px',
          '::placeholder': {
            color: '#CFD7E0'
          }
        },
        invalid: {
          iconColor: '#ffc7ee',
          color: '#ffc7ee'
        }
      }
    };
  }
}
