import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.less']
})
export class SliderComponent implements OnInit {
  /** картинки для карусели */
  @Input() images: Array<{ url: string; alt: string; isVisible: boolean; id: number }> = [];
  /** номер слайдера */
  slideNo: number = 0;

  constructor() { }

  ngOnInit(): void {
    this.сarousel(this.slideNo);
  }
  /** предыдущее изображение */
  prev(){
    this.slideNo === 0 ? this.slideNo : this.slideNo--;
    this.сarousel(this.slideNo);
  }
  /** следующее изображение */
  next(){
    this.slideNo === this.images.length - 1 ? this.slideNo : this.slideNo++;
    this.сarousel(this.slideNo);
  }
  /** инициализация карусели изображений */
  сarousel(index: number){
    const activeSlideIndex = this.images.findIndex(img => img.id === index);
    
    this.showSlide(activeSlideIndex);
  }

  /** показать слайд */
  private showSlide(activeSlideIndex: number) {
    this.images.map((image) => {
      image.id === activeSlideIndex ? image.isVisible = true : image.isVisible = false;
    });
  }
}
