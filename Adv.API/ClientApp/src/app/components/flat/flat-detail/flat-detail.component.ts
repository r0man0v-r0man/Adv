import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { FlatModel } from 'src/app/models/flatModel';
import { FlatService } from 'src/app/services/flat.service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { NzCarouselComponent } from 'ng-zorro-antd';
import { NavbarService } from 'src/app/services/navbar.service';
import { FooterService } from 'src/app/services/footer.service';
import ymaps from 'ymaps';

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

ymaps.load("https://api-maps.yandex.ru/2.1/?apikey=85e03f02-25be-40b3-971e-733f2a03e620&lang=ru_RU").then(maps => {
  var myMap = new maps.Map("map", {center:[55.753994, 37.622093], zoom:9});
  maps.geocode("Несвиж, Лермонтова д.2", {results:1}).then(function(res) {
    var firstGeoObject = res.geoObjects.get(0),
    coords = firstGeoObject.geometry.getCoordinates(),
    bounds = firstGeoObject.properties.get("boundedBy");
    firstGeoObject.options.set("preset", "islands#darkBlueDotIconWithCaption");
    firstGeoObject.properties.set("iconCaption", firstGeoObject.getAddressLine());
    myMap.geoObjects
     .add(firstGeoObject)
    myMap.setCenter(coords, 14);
    myMap.setBounds(bounds, {checkZoomRange:true});

  })
})
    console.log(this.coords);
    
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
