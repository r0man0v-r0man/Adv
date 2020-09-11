import { Injectable } from '@angular/core';
import { StripeCardNumberElement, StripeCardElement, CreateTokenCardData } from '@stripe/stripe-js';
import { FormGroup } from '@angular/forms';
import { StripeService } from 'ngx-stripe';
import { BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Constants } from '../constants';

@Injectable()
export class CheckoutService {
  headers = new HttpHeaders().set('content-type', 'application/json');
  
  isCheckoutSuccess = new BehaviorSubject(false);
  constructor(
    private stripeService: StripeService,
    private httpClient: HttpClient
  ) { }
  createCheckout(tokenType: StripeCardElement | StripeCardNumberElement, stripeForm: FormGroup) {
    const name = stripeForm.get('name').value; // отправляю id пользователя... можно будет посмотреть в кабинете на stripe.com
    this.stripeService.createToken(tokenType, { name }).subscribe((result) => {
      if(result.token) {
        const token = result.token.id;
        this.httpClient.post<boolean>(Constants.checkoutURL, { token }, { headers: this.headers }).subscribe((response) => {
          if(response) this.isCheckoutSuccess.next(response)
        })
      } else if (result.error) {
        // Error creating the token
        console.log(result.error.message);
      }
    })
  }
}
