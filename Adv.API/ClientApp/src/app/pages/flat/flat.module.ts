import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlatRoutingModule } from './flat-routing.module';
import { FlatSaleComponent } from './flat-sale/flat-sale.component';
import { FlatRentComponent } from './flat-rent/flat-rent.component';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzDescriptionsModule } from 'ng-zorro-antd/descriptions';
import { DurationPipe } from 'src/app/pipes/duration.pipe';
import { SliderComponent } from 'src/app/common/slider/slider.component';
import { BalconyPipe } from 'src/app/pipes/balcony.pipe';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';


@NgModule({
  declarations: [
    FlatSaleComponent, 
    FlatRentComponent,
    DurationPipe,
    BalconyPipe,
    SliderComponent
  ],
  imports: [
    CommonModule,
    FlatRoutingModule,
    NzGridModule,
    NzDescriptionsModule,
    NzDividerModule,
    NzBadgeModule,
    NzIconModule,
    NzButtonModule
  ]
})
export class FlatModule { }
