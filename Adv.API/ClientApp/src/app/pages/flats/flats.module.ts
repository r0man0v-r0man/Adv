import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlatsRoutingModule } from './flats-routing.module';
import { FlatsComponent } from './flats.component';
import { SaleComponent } from './sale/sale.component';
import { RentComponent } from './rent/rent.component';


@NgModule({
  declarations: [FlatsComponent, SaleComponent, RentComponent],
  imports: [
    CommonModule,
    FlatsRoutingModule
  ]
})
export class FlatsModule { }
