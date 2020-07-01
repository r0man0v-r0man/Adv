import { NgModule } from '@angular/core';

import { LoginRoutingModule } from './login-routing.module';

import { LoginComponent } from './login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NzFormModule } from 'ng-zorro-antd/form';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzTypographyModule } from 'ng-zorro-antd/typography';
import { NzIconModule } from 'ng-zorro-antd/icon';

@NgModule({
  imports: [
    LoginRoutingModule,
    FormsModule, 
    ReactiveFormsModule,
    NzFormModule,
    NzSpinModule,
    NzDividerModule,
    NzButtonModule,
    NzInputModule,
    NzTypographyModule,
    NzIconModule
  ],
  declarations: [LoginComponent],
  exports: [LoginComponent]
})
export class LoginModule { }
