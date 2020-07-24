import { NgModule } from '@angular/core';

import { HomeRoutingModule } from './home-routing.module';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { HomeComponent } from './home.component';
import { CommonModule } from '@angular/common';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { AdvertCardModule } from 'src/app/common/advert-card/advert-card.module';


@NgModule({
  imports: [
    HomeRoutingModule,
    CommonModule,
    NzGridModule,
    NzDividerModule,
    AdvertCardModule
  ],
  declarations: [
    HomeComponent
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
