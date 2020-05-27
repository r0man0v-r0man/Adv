import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlatRoutingModule } from './flat-routing.module';
import { FlatSaleComponent } from './flat-sale/flat-sale.component';
import { FlatRentComponent } from './flat-rent/flat-rent.component';


@NgModule({
  declarations: [
    FlatSaleComponent, 
    FlatRentComponent
  ],
  imports: [
    CommonModule,
    FlatRoutingModule
  ]
})
export class FlatModule { }
