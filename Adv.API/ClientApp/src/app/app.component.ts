import { Component, OnInit, AfterContentInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router, NavigationEnd, Event } from '@angular/router';
import { ModalService } from './services/modal.service';
import { DrawerService } from './services/drawer.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  linkedInUrl: string = 'https://www.linkedin.com/in/roman-romanov-276b0417a';
  currentUrl: string;
  isVisible: boolean = true;
  /** меняет ширину профиля по клику на гамбургер */
  isFullProfileDrawerWidth: boolean = false;
  isToggleMenu: boolean = false;
  constructor(
    private modalService: ModalService,
    private drawerService: DrawerService,
    private router: Router, 
    public authService: AuthService
  ) { }
  ngOnInit() {
    this.getCurrentUrl();
  }
  /** текущий URL */
  getCurrentUrl(){
    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationEnd ) {
        this.currentUrl = event.url;
        this.isVisible = this.setVisible(this.currentUrl);
      }
    });
  }
  /** установка видимости блоков */
  private setVisible(url: string){
    if(url === '/login' || url === '/register'){
      return false;
    }else {
      return true;
    }
  }
  /** переключение видимости меню если экран меньше 768 */
  onToggle(){
    this.isToggleMenu = !this.isToggleMenu;    
  }
  /** ширина профиля */
  onDrawer(){
    this.isFullProfileDrawerWidth = true;
  }
  /** показать профиль пользователя */
  openProfileDrawer(){
    this.drawerService.openCabinet(this.isFullProfileDrawerWidth);
  }
  /** показать модальное окно для добавления объявления */
  showAddAdvertModal(){
    this.modalService.advertCreateModal();
  }
  registerThenAddAdvert(){
    this.router.navigate(['/login']);
  }
}
