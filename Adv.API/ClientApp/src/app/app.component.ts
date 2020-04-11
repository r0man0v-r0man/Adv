import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { Title, Meta } from '@angular/platform-browser';
import { filter, map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {

  constructor(
    private titleService: Title,
    private metaService: Meta,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ){  }

  ngOnInit(): void {
    this.setApplicationMetaInfo();
  }
  
  /**set meta tags for SEO */
  setApplicationMetaInfo(){
    this.router.events
    .pipe(
      filter(event => event instanceof NavigationEnd),
    )
    .subscribe(() => {
        var rt = this.getChild(this.activatedRoute)
        rt.data.subscribe(data => {
          if(data.title){
            this.titleService.setTitle(data.title)
          }
          if (data.descrption) {
            this.metaService.updateTag({ name: 'description', content: data.descrption })
          } else {
            this.metaService.removeTag("name='description'")
          }
          if (data.robots) {
            this.metaService.updateTag({ name: 'robots', content: data.robots })
          } else {
            this.metaService.updateTag({ name: 'robots', content: "follow,index" })
          }
        })
      })
    }
    getChild(activatedRoute: ActivatedRoute) {
      if (activatedRoute.firstChild) {
        return this.getChild(activatedRoute.firstChild);
      } else {
        return activatedRoute;
      }
    }
}
