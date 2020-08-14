import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CutAdvertListComponent } from './cut-advert-list.component';
import { NzListModule } from 'ng-zorro-antd/list';
import { NZ_ICONS, NzIconModule } from 'ng-zorro-antd/icon';
import {
  SettingOutline,
  DeleteOutline,
  EditOutline
} from '@ant-design/icons-angular/icons';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
const icons = [
  SettingOutline,
  DeleteOutline,
  EditOutline
]

@NgModule({
  declarations: [
    CutAdvertListComponent
  ],
  imports: [
    CommonModule,
    NzListModule,
    NzIconModule,
    NzDropDownModule
  ],
  exports:[
    CutAdvertListComponent
  ],
  providers: [
    { provide: NZ_ICONS, useValue: icons }
  ]
})
export class CutAdvertListModule { }
