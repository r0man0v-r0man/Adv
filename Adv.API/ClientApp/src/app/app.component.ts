import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router, NavigationEnd, Event } from '@angular/router';
import { ModalService } from './services/modal.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  linkedInUrl: string = 'https://www.linkedin.com/in/roman-romanov-276b0417a';
  currentUrl: string;
  isVisible: boolean = true;
  isToggleMenu: boolean = false;
  constructor(
    private modalService: ModalService,
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
    if(url.includes('/login') || url.includes('/register')){
      return false;
    }else {
      return true;
    }
  }
  /** переключение видимости меню если экран меньше 768 */
  onToggle(){
    this.isToggleMenu = !this.isToggleMenu;    
  }
  /** показать модальное окно для добавления объявления */
  showAddAdvertModal(){
    this.modalService.advertCreateModal();
  }
  registerThenAddAdvert(){
    this.router.navigate(['/login']);
  }
}
