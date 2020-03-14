import { Component, OnInit, ViewChild } from '@angular/core';
import { FlatModel } from 'src/app/models/flatModel';
import { FlatService } from 'src/app/services/flat.service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
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
  isShowContacts: boolean = false;
  @ViewChild(NzCarouselComponent, { static: false }) 
  flatImageCarousel: NzCarouselComponent;

  constructor(
    private flatService:FlatService,
    route: ActivatedRoute,
    private router: Router,
    private navService: NavbarService,
    private footerService: FooterService

  ) { /** because in the same url component won't reload */
    route.params.subscribe(val => {
      this.getFlat(val['id']);
    });
   }

  ngOnInit() {
    this.navService.show();
    this.footerService.show();
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
  onShowContacts(){
    this.isShowContacts = !this.isShowContacts;
  }

}
