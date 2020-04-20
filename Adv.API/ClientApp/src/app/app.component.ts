import { Component, OnInit } from '@angular/core';
import { DisplayService } from './services/display.service';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';
import { ModalService } from './services/modal.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  linkedInUrl: string = 'https://www.linkedin.com/in/roman-romanov-276b0417a';
  isShowFooter: boolean;
  isShowNavBar: boolean;
  isUserLogin: boolean;
  /** меняет ширину профиля по клику на гамбургер */
  isFullProfileDrawerWidth: boolean = false;
  isToggleMenu: boolean = false;
  constructor(
    private displayService: DisplayService,
    private modalService: ModalService,
    private router: Router, 
    private authService: AuthService
  ) { }
  ngOnInit() {
    this.isShowFooter = this.displayService.isDisplayFooter;
    this.isShowNavBar = this.displayService.isDisplayNavBar;
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

  }
  /** показать модальное окно для добавления объявления */
  showAddAdvertModal(){
    this.modalService.advertCreateModal();
  }
  registerThenAddAdvert(){
    this.router.navigate(['/login']);
  }
}
