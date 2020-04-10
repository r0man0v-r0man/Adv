import { Component, OnInit } from '@angular/core';
import { NzModalService, NzDrawerService, NzNotificationService } from 'ng-zorro-antd';
import { AddAdvertComponent } from 'src/app/modal/add-advert/add-advert.component';
import { FlatService } from 'src/app/services/flat.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ProfileComponent } from 'src/app/drawers/profile/profile.component';
import { NavbarService } from 'src/app/services/navbar.service';
import { FlatModel } from 'src/app/models/flatModel';

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
          disabled: ()=> 
            !modal.getContentComponent().flatRentForm.valid || 
            !modal.getContentComponent().helperForm.valid,
          onClick: ()=>{
            this.createAdvert(modal);
            modal.destroy();
          }
        }
      ]
    });
  }
  /** Создание объявления */
  createAdvert(modal: any){
    //модель объявления - сдать квартиру
    const flatRent: FlatModel = { 
      ...modal.getContentComponent().flatRentForm.value
    } 
    //helper.advertType - сдать/продать и helper.realEstateType - квартира/дом
    const helper = modal.getContentComponent().helperForm.value;
    if(helper.advertType === 'сдать' && helper.realEstateType === 'квартира'){      
      this.flatService.createFlat(flatRent).subscribe(response => {
        if(response){
          this.showUserSuccessNotification();
          this.navigateToNewAdvert(response.id);
        }
      });
    }
  }
  /** показывает уведомление о создании объявления */
  showUserSuccessNotification(){
    this.notificationService.success(
      'Объявление создано',
      'Все хорошо, вы добавили новое объявление',
      {
        nzPauseOnHover: true
      })
  }
  /** переход на страницу с объявлением */
  navigateToNewAdvert(id:number){
    this.router.navigate(['flats/', id], {relativeTo: this.route.parent})
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
