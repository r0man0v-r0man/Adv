import {Component, Input} from '@angular/core';
import {YandexMapService} from '../../services/yandex-map.service';

@Component({
  selector: 'app-yandex-map',
  templateUrl: './yandex-map.component.html',
  styleUrls: ['./yandex-map.component.less'],
  providers: [
    YandexMapService
  ]
})
export class YandexMapComponent {
  @Input() advert;
  get mapCenter() {
    return this.yandexMapService.getCoords(this.advert.address);
  }
  constructor(
    private yandexMapService: YandexMapService
  ) { }

}
