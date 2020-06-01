import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.less']
})
export class SliderComponent implements OnInit {
  @Input() images: Array<{ url: string; alt: string; isVisible: boolean; id: number }> = [];
  constructor() { }

  ngOnInit(): void {
    console.log(this.images);
    
  }

}
