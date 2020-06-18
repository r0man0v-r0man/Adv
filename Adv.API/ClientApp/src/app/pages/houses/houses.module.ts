import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HousesRoutingModule } from './houses-routing.module';
import { HousesComponent } from './houses.component';
import { SaleComponent } from './sale/sale.component';
import { RentComponent } from './rent/rent.component';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzSelectModule } from 'ng-zorro-antd/select';

@NgModule({
  declarations: [
    HousesComponent, 
    SaleComponent, 
    RentComponent
  ],
  imports: [
    CommonModule,
    HousesRoutingModule,
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
export class HousesModule { }
