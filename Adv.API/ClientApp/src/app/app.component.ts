import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { ModalService } from './services/modal.service';
import { Title, Meta } from '@angular/platform-browser';
import { filter } from 'rxjs/operators';
import { SeoService } from './services/seo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  linkedInUrl: string = 'https://www.linkedin.com/in/roman-romanov-276b0417a';
  currentUrl: string;
  // видимость блоков навигации и футера
  isVisible: boolean = true;
  // переключение меню, моб. версия
  isToggleMenu: boolean = false;
  constructor(
    private seoService: SeoService,
    private router: Router, 
    private activatedRoute: ActivatedRoute,
    public authService: AuthService
  ) { }
  ngOnInit() {
    this.getCurrentUrl();
  }
  
  /** текущий URL */
  private getCurrentUrl(){
    this.router.events
    .pipe(filter(event => event instanceof NavigationEnd))
    .subscribe(() => {
      var routes = this.getChild(this.activatedRoute);
      routes.data.subscribe(data => {
        this.seoService.setMetaInfo(data);
        this.isVisible = this.setVisible(data);
      })
    });
  }
  
  private getChild(activatedRoute: ActivatedRoute) {
    if (activatedRoute.firstChild) {
      return this.getChild(activatedRoute.firstChild);
    } else {
      return activatedRoute;
    }
  }
  /** установка видимости блоков */
  private setVisible(data){
    return data.hideComponents ? false : true;
  }
  /** переключение видимости меню если экран меньше 768 */
  onToggle(){
    this.isToggleMenu = !this.isToggleMenu;    
  }  
}
