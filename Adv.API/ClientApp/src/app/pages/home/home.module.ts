import { NgModule } from '@angular/core';

import { HomeRoutingModule } from './home-routing.module';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { HomeComponent } from './home.component';
import { CommonModule } from '@angular/common';
import { NzCardModule } from 'ng-zorro-antd/card';


@NgModule({
  imports: [
    HomeRoutingModule,
    CommonModule,
    NzGridModule,
    NzCardModule
  ],
  declarations: [
    HomeComponent
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
