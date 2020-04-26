import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateAdvertRoutingModule } from './create-advert-routing.module';
import { CreateAdvertComponent } from './create-advert.component';


@NgModule({
  declarations: [CreateAdvertComponent],
  imports: [
    CommonModule,
    CreateAdvertRoutingModule
  ]
})
export class CreateAdvertModule { }
