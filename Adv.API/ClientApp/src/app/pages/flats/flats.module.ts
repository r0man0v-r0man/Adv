import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlatsRoutingModule } from './flats-routing.module';
import { FlatsComponent } from './flats.component';


@NgModule({
  declarations: [FlatsComponent],
  imports: [
    CommonModule,
    FlatsRoutingModule
  ]
})
export class FlatsModule { }
