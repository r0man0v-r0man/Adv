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
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { DescriptionInputModule } from '../Forms/description-input/description-input.module';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditAdvertComponent } from 'src/app/modals/edit-advert/edit-advert.component';
const icons = [
  SettingOutline,
  DeleteOutline,
  EditOutline
]

@NgModule({
  declarations: [
    CutAdvertListComponent,
    EditAdvertComponent
  ],
  imports: [
    CommonModule,
    NzListModule,
    NzIconModule,
    NzDropDownModule,
    NzDividerModule,
    DescriptionInputModule,
    NzGridModule,
    NzFormModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports:[
    CutAdvertListComponent
  ],
  providers: [
    { provide: NZ_ICONS, useValue: icons }
  ]
})
export class CutAdvertListModule { }
