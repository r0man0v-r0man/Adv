import { Component, OnInit } from '@angular/core';
import { NzModalService, NzDrawerService, NzNotificationService } from 'ng-zorro-antd';
import { AddAdvertComponent } from 'src/app/modal/add-advert/add-advert.component';
import { FlatService } from 'src/app/services/flat.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ProfileComponent } from 'src/app/drawers/profile/profile.component';
import { NavbarService } from 'src/app/services/navbar.service';

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
    private flatService: FlatService,
    private router: Router, 
    private route: ActivatedRoute,
    public authService: AuthService,
    private drawerService: NzDrawerService,
    public navService: NavbarService,
    private notificationService: NzNotificationService
    ) { }
  ngOnInit() {
    this.isFullProfileDrawerWidth = false;
  }
  /** переключение видимости меню если экран меньше 768 */
  onToggle(){
    this.isToggleMenu = !this.isToggleMenu;    
  }
  showAddAdvertModal(){
  const modal = this.modalService.create({
      nzTitle: 'Добавить объявление',
      nzContent: AddAdvertComponent,
      nzFooter:[
        {
          type: 'primary',
          label: 'Добавить',
          disabled: ()=> !modal.getContentComponent().flatRentForm.valid,
          onClick: ()=>{
            const modalForm = modal.getContentComponent().flatRentForm;
            if(modalForm.valid){
              let newFlatAdvert = modalForm.value;
              /** add userId for advert */
              newFlatAdvert.userId = this.authService.currentUser.sub;
              
              this.flatService
                .createFlat(newFlatAdvert)
                .subscribe(response => {
                    if(response){
                      this.notificationService.success(
                        'Объявление создано',
                        'Все хорошо, вы добавили новое объявление',
                        {
                          nzPauseOnHover: true
                        }
                      )
                      this.router.navigate(['flats/', response.id], {relativeTo: this.route.parent})
                    }
                  }
                );
              modal.destroy();
            }
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
