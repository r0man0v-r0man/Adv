import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlatRoutingModule } from './flat-routing.module';
import { FlatSaleComponent } from './flat-sale/flat-sale.component';
import { FlatRentComponent } from './flat-rent/flat-rent.component';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzDescriptionsModule } from 'ng-zorro-antd/descriptions';
import { BalconyPipe } from 'src/app/pipes/balcony.pipe';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { ToiletPipe } from 'src/app/pipes/toilet.pipe';
import { DurationModule } from 'src/app/pipes/modules/duration.module';
import { SliderModule } from 'src/app/common/slider/slider.module';
import {AngularYandexMapsModule} from 'angular8-yandex-maps';
import {YandexMapComponent} from '../../common/yandex-map/yandex-map.component';

@NgModule({
  declarations: [
    FlatSaleComponent,
    FlatRentComponent,
    BalconyPipe,
    ToiletPipe,
    YandexMapComponent
  ],
  imports: [
    CommonModule,
    FlatRoutingModule,
    NzGridModule,
    NzDescriptionsModule,
    NzDividerModule,
    DurationModule,
    NzIconModule,
    SliderModule,
    AngularYandexMapsModule
  ]
})
export class FlatModule { }
