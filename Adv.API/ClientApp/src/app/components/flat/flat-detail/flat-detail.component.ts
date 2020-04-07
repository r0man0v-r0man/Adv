import { Component, OnInit, ViewChild } from '@angular/core';
import { FlatModel } from 'src/app/models/flatModel';
import { FlatService } from 'src/app/services/flat.service';
import { ActivatedRoute, Params } from '@angular/router';
import { NzCarouselComponent } from 'ng-zorro-antd';
import { NavbarService } from 'src/app/services/navbar.service';
import { FooterService } from 'src/app/services/footer.service';
import ymaps from 'ymaps';
 
@Component({
  selector: 'app-flat-detail',
  templateUrl: './flat-detail.component.html',
  styleUrls: ['./flat-detail.component.less']
})

export class FlatDetailComponent implements OnInit{
  flat: FlatModel;
  isShowContacts: boolean = false;
  @ViewChild(NzCarouselComponent, { static: false })
  flatImageCarousel: NzCarouselComponent;
  myMap;
  flatId: number;
  images = [];
  constructor(
    private flatService:FlatService,
    private  route: ActivatedRoute,
    private navService: NavbarService,
    private footerService: FooterService
  ) { }

  ngOnInit() {
    this.initPage();
    this.createMap();
    this.navService.show();
    this.footerService.show();
    
  }
  initPage(){
    this.route.params.subscribe((params: Params)=>{
      let flatId = params['id'];
      this.flatService.getFlat(flatId).subscribe(
        response => {
          if(response){
            this.flat = { ...response }
            this.createMap();
            response.files.forEach((image, index)=>{
              let img = {
                url: image.linkProps.download
              }
              this.images.push(img);
            })
          }
      })
    })
    
    }
    /** создание карты, в сервис пока не переносим - потому что глюк с созданием карты при переходе
     */
    createMap(){
      ymaps.load("https://api-maps.yandex.ru/2.1/?apikey=85e03f02-25be-40b3-971e-733f2a03e620&lang=ru_RU")
      .then(maps => {
        const address = this.flat.street + ' ' + this.flat.numberOfHouse.toString();

        maps.geocode('Несвиж' + ' ' + address)
          .then((res)=>{
            if(!this.myMap){
              this.myMap = new maps.Map('map', {
                center: res.geoObjects.get(0).geometry.getCoordinates(),
                zoom : 14
              });
              var firstGeoObject = res.geoObjects.get(0);  
                  
              var bounds = firstGeoObject.properties.get("boundedBy");
              firstGeoObject.options.set("preset", "islands#darkBlueDotIconWithCaption");
              firstGeoObject.properties.set("iconCaption", firstGeoObject.getAddressLine());
              this.myMap.geoObjects.add(firstGeoObject)
              
              this.myMap.setBounds(bounds);
            }
            else{
              this.myMap.geoObjects.removeAll();

              var firstGeoObject = res.geoObjects.get(0);  
              var coords = firstGeoObject.geometry.getCoordinates();      
              var bounds = firstGeoObject.properties.get("boundedBy");
              firstGeoObject.options.set("preset", "islands#darkBlueDotIconWithCaption");
              firstGeoObject.properties.set("iconCaption", firstGeoObject.getAddressLine());
              this.myMap.geoObjects.add(firstGeoObject)
              this.myMap.setCenter(coords, 14);
              this.myMap.setBounds(bounds); 
            }
        });
      });
    }
    pre(){
      this.flatImageCarousel.pre();
    }
    next(){
      this.flatImageCarousel.next();
    }
    goToSlide(index:number){
      this.flatImageCarousel.goTo(index);
    }
    onImgClick(id: number){
      alert(id);
    }
    /** показать телефон */
    onShowContacts(){
      this.isShowContacts = !this.isShowContacts;
    }
}