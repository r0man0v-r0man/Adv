import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CutAdvertListComponent } from './cut-advert-list.component';
import { NzListModule } from 'ng-zorro-antd/list';



@NgModule({
  declarations: [
    CutAdvertListComponent
  ],
  imports: [
    CommonModule,
    NzListModule
  ],
  exports:[
    CutAdvertListComponent
  ]
})
export class CutAdvertListModule { }
