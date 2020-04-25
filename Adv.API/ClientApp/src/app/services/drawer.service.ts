import { Injectable } from '@angular/core';
import { NzDrawerService } from 'ng-zorro-antd/drawer';
import { AuthService } from './auth.service';
import { ProfileComponent } from '../drawers/profile/profile.component';

@Injectable({
  providedIn: 'root'
})
export class DrawerService {

  constructor(
    private nzDrawerService: NzDrawerService,
    private authService: AuthService
  ) { }
  openCabinet(isFullWidth: boolean){
    const user = this.authService.currentUser;
    const drawer = this.nzDrawerService.create({
      nzTitle: `${user.unique_name} - Кабинет пользователя`,
      nzContent: ProfileComponent,
      nzWidth: isFullWidth ? '100%' : '50%'
    })
  }
}
