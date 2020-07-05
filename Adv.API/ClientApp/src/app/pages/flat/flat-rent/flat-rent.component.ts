import { Component, OnInit } from '@angular/core';
import { Params, ActivatedRoute } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { NzUploadFile } from 'ng-zorro-antd/upload';
import {ILoadEvent} from 'angular8-yandex-maps';

@Component({
  selector: 'app-flat-rent',
  templateUrl: './flat-rent.component.html',
  styleUrls: ['./flat-rent.component.less']
})
export class FlatRentComponent implements OnInit {
  /** индентификатор объявления */
  advertId: number;
  /** объявление */
  advert: FlatRentModel;
  /** флаг загрузки */
  isLoading = true;
  /** изображения для слайдера */
  images: Array<{ url: string; alt: string; isVisible: boolean; id: number }> = [];

  phone = '+375-XX-XXX-XX-XX';
ggg;
  constructor(
    private route: ActivatedRoute,
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.initPage();
    this.ggg = {
      // Описание геометрии.
      geometry: {
        type: 'Point',
        coordinates: [55.8, 37.8]
      },
      // Свойства.
      properties: {
        // Контент метки.
        iconContent: 'Я тащусь',
        hintContent: 'Ну давай уже тащи'
      }
    };
  }

  /** инициализация страницы */
  private initPage() {
    this.route.params.subscribe((params: Params) => {
      this.advertId = params['id'];
      this.getAdvert(this.advertId);
    });
  }
  /** получение информации об объявлении */
  private getAdvert(id: number) {
    this.advertService.getFlatRent(id).subscribe(response => {
      if (response) {
        console.log(response);
        this.advert = response;
        this.initSlides(this.advert.images);
        this.isLoading = !this.isLoading;
      }
    });
  }
  /** преобразование картинок в слайды */
  initSlides(images: NzUploadFile[]) {
    const slides: Array<{ url: string; alt: string; isVisible: boolean; id: number }> = [];
    images.forEach((image, index) => {
      const img = {
        url: image.linkProps.download,
        alt: this.advert.address.description,
        isVisible: false,
        id: index
      };
      slides.push(img);
    });
    this.images = [...slides];
  }

  onLoad(event: ILoadEvent) {
    const myGeoObject = new event.ymaps.GeoObject({
      // Описание геометрии.
      geometry: {
        type: 'Point',
        coordinates: [53.226433, 26.675931]
      },
      // Свойства.
      properties: {
        // Контент метки.
        iconContent: 'Я тащусь',
        hintContent: 'Ну давай уже тащи'
      }
    }, {
      // Опции.
      // Иконка метки будет растягиваться под размер ее содержимого.
      preset: 'islands#blackStretchyIcon',
      // Метку можно перемещать.
      draggable: false
    });
    event.instance.geoObjects.add(myGeoObject);
    console.log(event);
  }
}
