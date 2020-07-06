import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlatsRoutingModule } from './flats-routing.module';
import { FlatsComponent } from './flats.component';
import { SaleComponent } from './sale/sale.component';
import { RentComponent } from './rent/rent.component';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { ProvinceInputComponent } from 'src/app/common/Forms/province-input/province-input.component';
@NgModule({
  declarations: [
    FlatsComponent,
    SaleComponent,
    RentComponent,
    ProvinceInputComponent
  ],
  imports: [
    CommonModule,
    FlatsRoutingModule,
    NzListModule,
    NzCardModule,
    NzGridModule,
    NzButtonModule,
    NzRadioModule,
    FormsModule,
    NzDividerModule,
    ReactiveFormsModule,
    NzFormModule,
    NzIconModule,
    NzSelectModule
  ]
})
export class FlatsModule { }
