import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HouseRoutingModule } from './house-routing.module';
import { HouseRentComponent } from './house-rent/house-rent.component';
import { HouseSaleComponent } from './house-sale/house-sale.component';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzDescriptionsModule } from 'ng-zorro-antd/descriptions';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { DurationModule } from 'src/app/pipes/modules/duration.module';

@NgModule({
  declarations: [
    HouseRentComponent,
    HouseSaleComponent,
    
  ],
  imports: [
    CommonModule,
    HouseRoutingModule,
    NzGridModule,
    NzDescriptionsModule,
    NzDividerModule,
    NzIconModule,
    DurationModule
  ]
})
export class HouseModule { }
