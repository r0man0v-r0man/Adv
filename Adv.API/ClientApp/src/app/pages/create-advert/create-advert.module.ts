import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateAdvertRoutingModule } from './create-advert-routing.module';
import { CreateAdvertComponent } from './create-advert.component';
import { NzGridModule } from 'ng-zorro-antd/grid';

import { NzRadioModule } from 'ng-zorro-antd/radio';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzTypographyModule } from 'ng-zorro-antd/typography';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
@NgModule({
  declarations: [CreateAdvertComponent],
  imports: [
    CommonModule,
    CreateAdvertRoutingModule,
    NzGridModule,
    NzRadioModule,
    FormsModule,
    ReactiveFormsModule,
    NzFormModule,
    NzTypographyModule,
    NzButtonModule,
    NzIconModule
  ]
})
export class CreateAdvertModule { }
