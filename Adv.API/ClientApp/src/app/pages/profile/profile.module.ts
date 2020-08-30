import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileComponent } from './profile.component';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { CutAdvertListModule } from 'src/app/common/cut-advert-list/cut-advert-list.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
@NgModule({
  declarations: [ProfileComponent],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    NzButtonModule,
    NzTabsModule,
    CutAdvertListModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class ProfileModule { }
