import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProvinceInputComponent } from './province-input.component';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ProvinceInputComponent
  ],
  imports: [
    CommonModule,
    NzSelectModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports:[
    ProvinceInputComponent
  ]
})
export class ProvinceInputModule { }
