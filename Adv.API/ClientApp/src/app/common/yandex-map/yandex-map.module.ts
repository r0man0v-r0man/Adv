import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {YandexMapComponent} from './yandex-map.component';
import {AngularYandexMapsModule} from 'angular8-yandex-maps';



@NgModule({
  declarations: [
    YandexMapComponent
  ],
  imports: [
    CommonModule,
    AngularYandexMapsModule
  ],
  exports: [
    YandexMapComponent
  ]
})
export class YandexMapModule { }
