import { Component, OnInit, ViewChild } from '@angular/core';
import { FlatModel } from 'src/app/models/flatModel';
import { FlatService } from 'src/app/services/flat.service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { Constants } from 'src/app/constants';
import { NzCarouselComponent } from 'ng-zorro-antd';
import { NavbarService } from 'src/app/services/navbar.service';
import { FooterService } from 'src/app/services/footer.service';

@Component({
  selector: 'app-flat-detail',
  templateUrl: './flat-detail.component.html',
  styleUrls: ['./flat-detail.component.less']
})

export class FlatDetailComponent implements OnInit {
  flat: FlatModel = new FlatModel();

  @ViewChild(NzCarouselComponent, { static: false }) 
  flatImageCarousel: NzCarouselComponent;

  constructor(
    private flatService:FlatService,
    private route: ActivatedRoute,
    private router: Router,
    private navService: NavbarService,
    private footerService: FooterService

  ) {  }

  ngOnInit() {
    this.navService.show();
    this.footerService.show();
    this.routeReUseStrategy();
    this.getFlat(this.getFlatIdFromRoute());
  }
  pre(){
    this.flatImageCarousel.pre();
  }
  next(){
    this.flatImageCarousel.next();
  }
  getFlat(id: number){
    this.flatService.getFlat(id)
    .subscribe(
      response => {
      this.flat = response
  });
  }
  /** for open detail after modal close */
  routeReUseStrategy(){
    // override the route reuse strategy
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
    this.router.events.subscribe((evt) => {
      if (evt instanceof NavigationEnd) {
        // trick the Router into believing it's last link wasn't previously loaded
        this.router.navigated = false;
      }
    });
  }


  getFlatIdFromRoute() : number {
    let flatId: number;
    this.route.params.subscribe(params =>{
      flatId = params['id'];
    })
    return flatId;
  }

}