import { Component, OnInit, AfterViewInit, ViewChildren, QueryList, ViewChild, ElementRef, Renderer2 } from '@angular/core';
import { Params, ActivatedRoute } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { UploadFile } from 'ng-zorro-antd/upload/interface';

@Component({
  selector: 'app-flat-rent',
  templateUrl: './flat-rent.component.html',
  styleUrls: ['./flat-rent.component.less']
})
export class FlatRentComponent implements OnInit, AfterViewInit {
  /** индентификатор объявления */
  advertId: number;
  /** объявление */
  advert: FlatRentModel;
  /** флаг загрузки */
  isLoading: boolean = true;

  @ViewChild('slideshow_container') s_c: ElementRef;
  constructor(
    private route: ActivatedRoute,
    private advertService: AdvertService,
    private renderer: Renderer2,
    private elem: ElementRef
  ) { }
  ngAfterViewInit(): void {
    this.renderer.appendChild(this.s_c.nativeElement, this.renderer.createElement('img'));
    
  }

  ngOnInit(): void {
    this.initPage();
  }

  /** инициализация страницы */
  private initPage(){
    this.route.params.subscribe((params: Params) => {
      this.advertId = params['id'];
      this.getAdvert(this.advertId);
    })
  }
  /** получение информации об объявлении */
  private getAdvert(id: number){
    this.advertService.getFlatRent(id).subscribe(response => {
      if(response){
        this.advert = response;
        this.initSlides(this.advert.images);
        this.isLoading = !this.isLoading;
      }
    });
  }




  slideNo = 1;
  images: Array<{url: string; alt: string; }> = [];
  initSlides(images: UploadFile[]){
    let slides: Array<{url: string; alt: string;  }> = [];
    images.forEach((image)=>{
      let img = {
        url: image.linkProps.download,
        alt: this.advert.address
      }
      slides.push(img);
    })
    this.images = [...slides];
    
  }
  prev(){
    (document.getElementsByClassName("image-container")[0] as HTMLElement).style.display = "none";
  }

}
