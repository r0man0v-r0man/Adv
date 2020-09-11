import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StripeCardElementOptions } from '@stripe/stripe-js';

@Injectable()
export class CheckoutFormService {
  form: FormGroup;
  constructor(
    private fb: FormBuilder
  ) { 
    this.initForm();
  }
  initForm() {
    this.form = this.fb.group({
      name: ['за объявление', [Validators.required]]
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
        }
      }
    };
  }
}
