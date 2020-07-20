import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlatsRoutingModule } from './flats-routing.module';
import { FlatsComponent } from './flats.component';
import { SaleComponent } from './sale/sale.component';
import { RentComponent } from './rent/rent.component';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { AdvertCardModule } from 'src/app/common/advert-card/advert-card.module';
import { ProvinceInputModule } from 'src/app/common/Forms/province-input/province-input.module';
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
    NzGridModule,
    NzButtonModule,
    NzRadioModule,
    FormsModule,
    NzDividerModule,
    ReactiveFormsModule,
    NzFormModule,
    NzIconModule,
    NzSelectModule,
    AdvertCardModule,
    ProvinceInputModule
  ]
})
export class FlatsModule { }
