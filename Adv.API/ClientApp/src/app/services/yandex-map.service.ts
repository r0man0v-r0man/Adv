import {Injectable} from '@angular/core';
import {ILoadEvent} from 'angular8-yandex-maps';

@Injectable()
export class YandexMapService {
  constructor() { }
  getGeoObject(address: any) {
    const coords = this.getCoords(address);
    return {
      // Описание геометрии.
      geometry: {
        type: 'Point',
        coordinates: [coords[1], coords[0]]
      },
      // Свойства.
      properties: {
        // Контент метки.
        iconContent: `${ address.geoObject.name }`
      }
    };
  }
  getproperties() {
    return {
      // Опции.
      // Иконка метки будет растягиваться под размер ее содержимого.
      preset: 'islands#blackStretchyIcon',
      // Метку можно перемещать.
      draggable: false
    };
  }
  getCoords(address: any) {
    return address.geoObject.point.pos.split(' ');
  }
  onLoad(event: ILoadEvent, address: any) {
    const myGeoObject = new event.ymaps.GeoObject(
      this.getGeoObject(address),
      this.getproperties());
    event.instance.geoObjects.add(myGeoObject);
  }
}
