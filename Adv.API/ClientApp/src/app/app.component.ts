import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { ModalService } from './services/modal.service';
import { Title, Meta } from '@angular/platform-browser';
import { filter } from 'rxjs/operators';

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
    private titleService: Title,
    private metaService: Meta,
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
        this.setMetaInfo(data);
        this.isVisible = this.setVisible(data);
      })
    });
  }
  /** установка СЕО данных для страницы */
  private setMetaInfo(data){
    if(data.title){
      this.titleService.setTitle(data.title)
    }
    if (data.description) {
      this.metaService.updateTag({ name: 'description', content: data.description })
    } else {
      this.metaService.removeTag("name='description'")
    }
    if (data.robots) {
      this.metaService.updateTag({ name: 'robots', content: data.robots })
    } else {
      this.metaService.updateTag({ name: 'robots', content: "follow,index" })
    }
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
