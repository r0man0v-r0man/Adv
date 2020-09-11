import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutComponent } from './checkout.component';
import { NgxStripeModule } from 'ngx-stripe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule, NZ_ICONS } from 'ng-zorro-antd/icon';
import {
  WalletOutline,
  CheckOutline
} from '@ant-design/icons-angular/icons';
import { NzGridModule } from 'ng-zorro-antd/grid';
const icons = {
  WalletOutline,
  CheckOutline
}

@NgModule({
  declarations: [
    CheckoutComponent
  ],
  imports: [
    CommonModule,
    NzGridModule,
    FormsModule,
    ReactiveFormsModule,
    NzButtonModule,
    NzIconModule,
    NgxStripeModule.forRoot('pk_test_51HOpoZBXPSAG0EhSFjBwnh9jFI8m7FPICtihjLipglD1AWQERa1AfhALa7WDia2U8JTbqYQJFStdkys0qmgQI3rj00QkZt98uM')
  ],
  exports:[
    CheckoutComponent
  ],
  providers: [
    { provide: NZ_ICONS, useValue: icons }
  ]
})
export class CheckoutModule { }
