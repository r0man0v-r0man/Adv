import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdvertCardComponent } from './advert-card.component';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzIconModule, NZ_ICONS } from 'ng-zorro-antd/icon';
import {
  EnvironmentOutline
} from '@ant-design/icons-angular/icons';

const icons = [
  EnvironmentOutline
];


@NgModule({
  declarations: [
    AdvertCardComponent
  ],
  imports: [
    CommonModule,
    NzCardModule,
    NzIconModule
  ],
  exports: [
    AdvertCardComponent
  ],
  providers: [
    { provide: NZ_ICONS, useValue: icons }
  ]
})
export class AdvertCardModule { }
