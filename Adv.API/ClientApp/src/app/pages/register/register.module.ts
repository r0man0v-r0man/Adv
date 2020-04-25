import { NgModule, ErrorHandler } from '@angular/core';

import { RegisterRoutingModule } from './register-routing.module';

import { RegisterComponent } from './register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NzFormModule } from 'ng-zorro-antd/form';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzTypographyModule } from 'ng-zorro-antd/typography';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { CommonModule } from '@angular/common';
import { AppErrorHandler } from 'src/app/errors/appErrorHandler';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpErrorInterceptor } from 'src/app/errors/httpError.interceptor';

@NgModule({
  imports: [
    RegisterRoutingModule,
    FormsModule, 
    ReactiveFormsModule,
    NzFormModule,
    NzSpinModule,
    NzButtonModule,
    NzInputModule,
    NzTypographyModule,
    NzIconModule,
    CommonModule
  ],
  declarations: [RegisterComponent],
  exports: [RegisterComponent]
})
export class RegisterModule { }
