import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar.component';
import { FormsModule } from '@angular/forms';
import { NzIconModule, NZ_ICONS } from 'ng-zorro-antd/icon';
import {
  MenuOutline
} from '@ant-design/icons-angular/icons';
import { AppRoutingModule } from 'src/app/app-routing.module';
const icons = [
  MenuOutline
]
@NgModule({
  declarations: [
    NavbarComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzIconModule,
    AppRoutingModule,
  ],
  exports:[
    NavbarComponent
  ],
  providers: [
    { provide: NZ_ICONS, useValue: icons }
  ]
})
export class NavbarModule { }
