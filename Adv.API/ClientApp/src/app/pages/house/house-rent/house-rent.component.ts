import { Component, OnInit } from '@angular/core';
import { AdvertService } from 'src/app/services/advert.service';
import { ActivatedRoute, Params } from '@angular/router';
import { HouseRentModel } from 'src/app/models/house-rent.model';
import { NzUploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'app-house-rent',
  templateUrl: './house-rent.component.html',
  styleUrls: ['./house-rent.component.less']
})
export class HouseRentComponent implements OnInit {
  /** индентификатор объявления */
  advertId: number;
  /** объявление */
  advert: HouseRentModel;
  /** флаг загрузки */
  isLoading = true;

  /** изображения для слайдера */
  images: Array<{ url: string; alt: string; isVisible: boolean; id: number }> = [];

  phone = '+375-XX-XXX-XX-XX';

  constructor(
    private route: ActivatedRoute,
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.initPage();
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
    this.advertService.getHouseRent(id).subscribe(response => {
      if (response) {
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
        alt: this.advert.address.exactLocation,
        isVisible: false,
        id: index
      };
      slides.push(img);
    });
    this.images = [...slides];
  }
}
