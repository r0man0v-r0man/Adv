import { NgModule } from '@angular/core';
import { NZ_ICONS, NzIconModule } from 'ng-zorro-antd/icon';

import {
  HomeOutline,
  LoginOutline,
  LogoutOutline,
  PlusCircleOutline,
  MenuOutline,
  LockOutline,
  UserOutline,
  RightOutline,
  UploadOutline,
  CheckOutline,
  StopOutline
} from '@ant-design/icons-angular/icons';

const icons = [
  HomeOutline, 
  LoginOutline,
  LogoutOutline,
  PlusCircleOutline,
  MenuOutline,
  LockOutline,
  UserOutline,
  RightOutline,
  UploadOutline,
  CheckOutline,
  StopOutline
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
