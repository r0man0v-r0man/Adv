import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
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

export class FlatDetailComponent implements OnInit, AfterViewInit {
  flat: FlatModel = new FlatModel();
  isShowContacts: boolean = false;
  @ViewChild(NzCarouselComponent) 
  flatImageCarousel: NzCarouselComponent;

  public clusterer = {
    preset: 'islands#invertedVioletClusterIcons',
    hasBaloon: false
  };
  coords;
  

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
  ngAfterViewInit(): void {
  }

  ngOnInit() {
    this.navService.show();
    this.footerService.show();    
  }
  public onLoad(event) {
    
    const ymaps = event.ymaps;
    
    ymaps.geocode('Несвиж, улица Лермонтова д.2')
      .then((res) => {
         // Координаты геообъекта.
        this.coords = res.geoObjects.get(0).geometry.getCoordinates();
         // Область видимости геообъекта.
        let bounds = res.geoObjects.get(0).properties.get('boundedBy');

        console.log(this.coords);
        
      });
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
