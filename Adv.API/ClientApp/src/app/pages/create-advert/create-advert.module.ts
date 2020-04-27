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

import { RentFlatComponent } from './components/rent-flat/rent-flat.component';
import { SaleFlatComponent } from './components/sale-flat/sale-flat.component';
import { SaleHouseComponent } from './components/sale-house/sale-house.component';
import { RentHouseComponent } from './components/rent-house/rent-house.component';
@NgModule({
  declarations: [CreateAdvertComponent, RentFlatComponent, SaleFlatComponent, SaleHouseComponent, RentHouseComponent],
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
    NzUploadModule
  ]
})
export class CreateAdvertModule { }
