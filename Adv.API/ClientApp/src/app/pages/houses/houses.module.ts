import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HousesRoutingModule } from './houses-routing.module';
import { HousesComponent } from './houses.component';
import { SaleComponent } from './sale/sale.component';
import { RentComponent } from './rent/rent.component';


@NgModule({
  declarations: [HousesComponent, SaleComponent, RentComponent],
  imports: [
    CommonModule,
    HousesRoutingModule
  ]
})
export class HousesModule { }
