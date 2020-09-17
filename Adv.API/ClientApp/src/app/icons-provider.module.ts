import { NgModule } from '@angular/core';
import { NZ_ICONS, NzIconModule } from 'ng-zorro-antd/icon';

import {
  HomeOutline,
  LoginOutline,
  LogoutOutline,
  PlusCircleOutline,
  LockOutline,
  UserOutline,
  RightOutline,
  UploadOutline,
  CheckOutline,
  StopOutline,
  PhoneOutline,
  FilterOutline,
  DatabaseOutline,
  EnterOutline,
  EnvironmentOutline
} from '@ant-design/icons-angular/icons';

const icons = [
  HomeOutline, 
  LoginOutline,
  LogoutOutline,
  PlusCircleOutline,
  LockOutline,
  UserOutline,
  RightOutline,
  UploadOutline,
  CheckOutline,
  StopOutline,
  PhoneOutline,
  FilterOutline,
  DatabaseOutline,
  EnterOutline,
  EnvironmentOutline
];

@NgModule({
  imports: [NzIconModule],
  exports: [NzIconModule],
  providers: [
    { provide: NZ_ICONS, useValue: icons }
  ]
})
export class IconsProviderModule {
}
