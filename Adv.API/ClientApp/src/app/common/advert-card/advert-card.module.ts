import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdvertCardComponent } from './advert-card.component';
import { NzCardModule } from 'ng-zorro-antd/card';



@NgModule({
  declarations: [
    AdvertCardComponent
  ],
  imports: [
    CommonModule,
    NzCardModule
  ],
  exports: [
    AdvertCardComponent
  ]
})
export class AdvertCardModule { }
