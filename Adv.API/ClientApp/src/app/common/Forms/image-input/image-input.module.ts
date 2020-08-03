import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzUploadModule } from 'ng-zorro-antd/upload';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ImageInputComponent } from './image-input.component';
import { NzButtonModule } from 'ng-zorro-antd/button';

@NgModule({
  declarations: [
    ImageInputComponent
  ],
  imports: [
    NzUploadModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NzButtonModule
  ],
  exports: [
    ImageInputComponent
  ]
})
export class ImageInputModule { }
