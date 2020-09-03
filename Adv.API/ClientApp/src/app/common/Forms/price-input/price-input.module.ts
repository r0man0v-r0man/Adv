import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PriceInputComponent } from './price-input.component';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzGridModule } from 'ng-zorro-antd/grid';



@NgModule({
  declarations: [
    PriceInputComponent
  ],
  imports: [
    CommonModule,
    NzInputModule,
    NzInputNumberModule,
    FormsModule,
    ReactiveFormsModule,
    NzFormModule,
    NzGridModule
  ],
  exports:[
    PriceInputComponent
  ]
})
export class PriceInputModule { }
