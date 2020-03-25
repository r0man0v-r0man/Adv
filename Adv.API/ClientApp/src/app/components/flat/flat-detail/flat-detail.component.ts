import { Component, OnInit, ViewChild, AfterViewInit, OnChanges } from '@angular/core';
import { FlatModel } from 'src/app/models/flatModel';
import { FlatService } from 'src/app/services/flat.service';
import { ActivatedRoute } from '@angular/router';
import { NzCarouselComponent } from 'ng-zorro-antd';
import { NavbarService } from 'src/app/services/navbar.service';
import { FooterService } from 'src/app/services/footer.service';
import { YandexMapService } from 'src/app/services/yandex-map.service';

@Component({
  selector: 'app-flat-detail',
  templateUrl: './flat-detail.component.html',
  styleUrls: ['./flat-detail.component.less']
})

export class FlatDetailComponent implements OnInit,  AfterViewInit {
  flat: FlatModel;
  isShowContacts: boolean = false;
  @ViewChild(NzCarouselComponent) 
  flatImageCarousel: NzCarouselComponent;

  constructor(
    private flatService:FlatService,
    private  route: ActivatedRoute,
    private navService: NavbarService,
    private footerService: FooterService,
    private yandexMapService: YandexMapService
  ) { /** because in the same url component won't reload */
    // route.params.subscribe(val => {
    //   this.getFlat(val['id']);
    // });
   }
  
  ngAfterViewInit(): void {    
    
  }

  ngOnInit() {
    this.route.params.subscribe(val => {
      this.getFlat(val['id']);
    });
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
    .subscribe(response => {
      if(response){
        this.flat = response;
        const address = this.flat.street + ' ' + this.flat.numberOfHouse.toString();
        this.yandexMapService.loadMap('несвиж', address, 'map');
      }

  });
  }
  onShowContacts(){
    this.isShowContacts = !this.isShowContacts;
  }

}
