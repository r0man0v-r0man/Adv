import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DescriptionInputComponent } from './description-input.component';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzFormModule } from 'ng-zorro-antd/form';


@NgModule({
  declarations: [
    DescriptionInputComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NzInputModule,
    NzFormModule
  ],
  exports:[
    DescriptionInputComponent
  ]
})
export class DescriptionInputModule { }
