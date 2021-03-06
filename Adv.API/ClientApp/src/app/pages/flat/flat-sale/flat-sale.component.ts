import { Component, OnInit } from '@angular/core';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { AdvertService } from 'src/app/services/advert.service';
import { ActivatedRoute, Params } from '@angular/router';
import { NzUploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'app-flat-sale',
  templateUrl: './flat-sale.component.html',
  styleUrls: ['./flat-sale.component.less']
})
export class FlatSaleComponent implements OnInit {
  /** индентификатор объявления */
  advertId: number;
  /** объявление */
  advert: FlatSaleModel;
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
    this.advertService.getFlatSale(id).subscribe(response => {
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
        alt: this.advert.address.description,
        isVisible: false,
        id: index
      };
      slides.push(img);
    });
    this.images = [...slides];
  }
}
