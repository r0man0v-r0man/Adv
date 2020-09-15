import { Component, forwardRef, OnInit, ViewChild } from '@angular/core';
import { StripeElementsOptions, StripeCardElementChangeEvent } from '@stripe/stripe-js';
import { StripeCardComponent } from 'ngx-stripe';
import { CheckoutFormService } from './service/checkout-form.service';
import { CheckoutService } from 'src/app/services/checkout.service';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.less'],
  providers: [
    CheckoutFormService,
    CheckoutService,
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CheckoutComponent),
      multi: true
    }
  ]
})
export class CheckoutComponent implements OnInit, ControlValueAccessor {
  @ViewChild(StripeCardComponent) card: StripeCardComponent;
  isValidStripeForm = false;
  isPaySuccess = false;
  isValid = false;
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
  onChange: any = () => {};
  onTouched: any = () => {};
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
  writeValue(input: boolean): void {
    this.isValid = input;
  }
  ngOnInit(): void {    
    this.checkoutService.isCheckoutSuccess.subscribe(data => {
      if(data) {
        this.isPaySuccess = data;
        this.onChange(true)
      }
    })
  }
  createToken(): void {
    this.checkoutService.createCheckout(this.card.element, this.stripeForm);
  }
  onChangeCard(ev: StripeCardElementChangeEvent) {
    const displayError = document.getElementById('card-errors');
    if (ev.error) {
      this.isValidStripeForm = false;
      displayError.textContent = ev.error.message;
    } else {
      this.isValidStripeForm = true;
      displayError.textContent = '';
    }
    if (!ev.complete && !ev.error && !ev.empty) {
      this.isValidStripeForm = false;
    }
  }
}
