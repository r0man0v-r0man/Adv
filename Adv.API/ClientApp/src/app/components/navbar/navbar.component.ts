import { Component, OnInit } from '@angular/core';
import { NzModalService, NzDrawerService } from 'ng-zorro-antd';
import { AddAdvertComponent } from 'src/app/modal/add-advert/add-advert.component';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ProfileComponent } from 'src/app/drawers/profile/profile.component';
import { NavbarService } from 'src/app/services/navbar.service';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.less']
})
export class NavbarComponent implements OnInit {
  isLogedIn :boolean = false;
  newFlatId;
  isToggleMenu: boolean = false;
  /** меняет ширину профиля по клику на гамбургер */
  isFullProfileDrawerWidth: boolean;
  constructor(
    private modalService: NzModalService, 
    private advertService: AdvertService,
    private router: Router, 
    public authService: AuthService,
    private drawerService: NzDrawerService,
    public navService: NavbarService,
    ) { }
  ngOnInit() {
    this.isFullProfileDrawerWidth = false;
  }
  /** переключение видимости меню если экран меньше 768 */
  onToggle(){
    this.isToggleMenu = !this.isToggleMenu;    
  }
  /** показать модальное окно для добавления объявления */
  showAddAdvertModal(){
  const modal = this.modalService.create({
      nzTitle: 'Добавить объявление',
      nzContent: AddAdvertComponent,
      nzFooter:[
        {
          type: 'primary',
          label: 'Добавить',
          disabled: ()=> 
            !modal.getContentComponent().flatRentForm.valid || 
            !modal.getContentComponent().helperForm.valid,
          onClick: ()=>{
            this.advertService.createAdvert(modal);
            modal.destroy();
          }
        }
      ]
    });
  }
  
  /**
   * redirect to login page if user is not logedIn
   */
  registerThenAddAdvert(){
    this.router.navigate(['/login']);
  }
  /**
   * open profile drawer
   */
  openProfileDrawer(){
    const user = this.authService.currentUser;
    const drawer = this.drawerService.create({
      nzTitle: `${user.unique_name} - Кабинет пользователя`,
      nzContent: ProfileComponent,
      nzWidth: this.isFullProfileDrawerWidth ? '100%' : '50%'
    })
  }
  /** ширина профиля */
  onDrawer(){
    this.isFullProfileDrawerWidth = true;
  }
}
