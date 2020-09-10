import { Component, OnInit, ViewChild } from '@angular/core';
import { StripeCardComponent, StripeService, StripeCardNumberComponent } from 'ngx-stripe';
import { StripeCardElementOptions, StripeElementsOptions } from '@stripe/stripe-js';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Constants } from 'src/app/constants';

@Component({
  selector: 'app-create-token',
  templateUrl: './create-token.component.html',
  styleUrls: ['./create-token.component.less']
})
export class CreateTokenComponent implements OnInit {
  @ViewChild(StripeCardComponent) card: StripeCardComponent;

  cardOptions: StripeCardElementOptions = {
    hidePostalCode: true,
    style: {
      base: {
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

  elementsOptions: StripeElementsOptions = {
    locale: 'ru'
  };

  stripeTest: FormGroup;

  constructor(
    private fb: FormBuilder, 
    private stripeService: StripeService,
    private http: HttpClient
    ) {}

  ngOnInit(): void {
    this.stripeTest = this.fb.group({
      name: ['за объявление', [Validators.required]]
    });
  }

  createToken(): void {
    const name = this.stripeTest.get('name').value;
    const headers = new HttpHeaders().set('content-type', 'application/json');
    this.stripeService
      .createToken(this.card.element, { name })
      .subscribe((result) => {
        if (result.token) {
          console.log(result.token);
          const token = result.token.id
          this.http.post<boolean>(Constants.checkoutURL, { token }, {headers: headers}).subscribe(response => {
            console.log('response is: ', response);
            
          })
          // Use the token
          console.log(result.token.id);
        } else if (result.error) {
          // Error creating the token
          console.log(result.error.message);
        }
      });
  }
}