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

@NgModule({
  declarations: [
    FlatsComponent, 
    SaleComponent, 
    RentComponent
  ],
  imports: [
    CommonModule,
    FlatsRoutingModule,
    NzListModule,
    NzCardModule,
    NzGridModule,
    NzButtonModule
  ]
})
export class FlatsModule { }
