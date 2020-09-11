import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { StripeElementsOptions, StripeCardElementOptions } from '@stripe/stripe-js';
import { StripeCardComponent } from 'ngx-stripe';
import { CheckoutFormService } from './service/checkout-form.service';
import { CheckoutService } from 'src/app/services/checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.less'],
  providers: [
    CheckoutFormService,
    CheckoutService
  ]
})
export class CheckoutComponent implements OnInit {
  @ViewChild(StripeCardComponent) card: StripeCardComponent;

  isPaySuccess = false;
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
    private checkoutFormService: CheckoutFormService,
    private checkoutService: CheckoutService
  ) { }

  ngOnInit(): void {
    this.checkoutService.isCheckoutSuccess.subscribe(data => {
      if(data) this.isPaySuccess = data;
    })
  }
  createToken(): void {
    
    this.checkoutService.createCheckout(this.card.element, this.stripeForm);
  }
}
