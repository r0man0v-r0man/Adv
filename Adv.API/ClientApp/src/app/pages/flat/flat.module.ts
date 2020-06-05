import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlatRoutingModule } from './flat-routing.module';
import { FlatSaleComponent } from './flat-sale/flat-sale.component';
import { FlatRentComponent } from './flat-rent/flat-rent.component';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzDescriptionsModule } from 'ng-zorro-antd/descriptions';
import { SliderComponent } from 'src/app/common/slider/slider.component';
import { BalconyPipe } from 'src/app/pipes/balcony.pipe';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { ToiletPipe } from 'src/app/pipes/toilet.pipe';
import { DurationModule } from 'src/app/pipes/modules/duration.module';


@NgModule({
  declarations: [
    FlatSaleComponent, 
    FlatRentComponent,
    
    BalconyPipe,
    ToiletPipe,
    SliderComponent
  ],
  imports: [
    CommonModule,
    FlatRoutingModule,
    NzGridModule,
    NzDescriptionsModule,
    NzDividerModule,
    DurationModule,
    NzIconModule
  ]
})
export class FlatModule { }
