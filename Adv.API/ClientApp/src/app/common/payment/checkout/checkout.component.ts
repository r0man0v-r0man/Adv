import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { StripeElementsOptions, StripeCardElementOptions } from '@stripe/stripe-js';
import { StripeCardComponent } from 'ngx-stripe';
import { CheckoutFormService } from './service/checkout-form.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.less'],
  providers: [
    CheckoutFormService
  ]
})
export class CheckoutComponent implements OnInit {
  @ViewChild(StripeCardComponent) card: StripeCardComponent;



  elementsOptions: StripeElementsOptions = {
    locale: 'ru'
  };

  get stripeForm() {
    return this.checkoutFormService.form
  }
  get cardOptions() {
    return this.checkoutFormService.initCardOptions();
  }
  constructor(
    private checkoutFormService: CheckoutFormService
  ) { }

  ngOnInit(): void {
  }
  createToken(): void {
    console.log('createToken');
    
  }
}
