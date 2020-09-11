import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateAdvertRoutingModule } from './create-advert-routing.module';
import { CreateAdvertComponent } from './create-advert.component';
import { NzGridModule } from 'ng-zorro-antd/grid';

import { NzRadioModule } from 'ng-zorro-antd/radio';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzTypographyModule } from 'ng-zorro-antd/typography';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzUploadModule } from 'ng-zorro-antd/upload';
import { NzAutocompleteModule } from 'ng-zorro-antd/auto-complete';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { RentFlatComponent } from './components/rent-flat/rent-flat.component';
import { SaleFlatComponent } from './components/sale-flat/sale-flat.component';
import { SaleHouseComponent } from './components/sale-house/sale-house.component';
import { RentHouseComponent } from './components/rent-house/rent-house.component';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import {AddressInputComponent} from '../../common/Forms/address-input/address-input.component';
import { DescriptionInputModule } from 'src/app/common/Forms/description-input/description-input.module';
import { PriceInputModule } from 'src/app/common/Forms/price-input/price-input.module';
import { CheckoutModule } from 'src/app/common/payment/checkout/checkout.module';

@NgModule({
  declarations: [
    CreateAdvertComponent,
    RentFlatComponent,
    SaleFlatComponent,
    SaleHouseComponent,
    RentHouseComponent,
    AddressInputComponent
  ],
  imports: [
    CommonModule,
    CreateAdvertRoutingModule,
    NzGridModule,
    NzRadioModule,
    FormsModule,
    ReactiveFormsModule,
    NzFormModule,
    NzTypographyModule,
    NzButtonModule,
    NzIconModule,
    NzUploadModule,
    NzAutocompleteModule,
    NzInputModule,
    NzSelectModule,
    NzInputNumberModule,
    NzDividerModule,
    NzCheckboxModule,
    DescriptionInputModule,
    PriceInputModule,
    CheckoutModule
  ]
})
export class CreateAdvertModule { }
