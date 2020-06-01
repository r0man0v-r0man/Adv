import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlatRoutingModule } from './flat-routing.module';
import { FlatSaleComponent } from './flat-sale/flat-sale.component';
import { FlatRentComponent } from './flat-rent/flat-rent.component';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzDescriptionsModule } from 'ng-zorro-antd/descriptions';
import { DurationPipe } from 'src/app/pipes/duration.pipe';
import { NzSkeletonModule } from 'ng-zorro-antd/skeleton';
import { SliderComponent } from 'src/app/common/slider/slider.component';
@NgModule({
  declarations: [
    FlatSaleComponent, 
    FlatRentComponent,
    DurationPipe,
    SliderComponent
  ],
  imports: [
    CommonModule,
    FlatRoutingModule,
    NzGridModule,
    NzDescriptionsModule,
    NzSkeletonModule
  ]
})
export class FlatModule { }
