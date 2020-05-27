import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlatRoutingModule } from './flat-routing.module';
import { FlatComponent } from './flat.component';


@NgModule({
  declarations: [FlatComponent],
  imports: [
    CommonModule,
    FlatRoutingModule
  ]
})
export class FlatModule { }
