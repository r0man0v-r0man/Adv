import { Injectable } from '@angular/core';
import ymaps from 'ymaps';

@Injectable({
  providedIn: 'root'
})
export class YandexMapService {
  
  constructor() { }

  loadMap(city: string, address: string, htmlContainerId:string){
   
    ymaps.load("https://api-maps.yandex.ru/2.1/?apikey=85e03f02-25be-40b3-971e-733f2a03e620&lang=ru_RU").then(maps => {
      var myMap = new maps.Map(`${htmlContainerId}`, {center:[55.753994, 37.622093], zoom:14});
      maps.geocode(`${city}, ${address}`, {results:1}).then(function(res) {
        var firstGeoObject = res.geoObjects.get(0),
        coords = firstGeoObject.geometry.getCoordinates(),
        bounds = firstGeoObject.properties.get("boundedBy");
        firstGeoObject.options.set("preset", "islands#darkBlueDotIconWithCaption");
        firstGeoObject.properties.set("iconCaption", firstGeoObject.getAddressLine());
        myMap.geoObjects.add(firstGeoObject)
        myMap.setCenter(coords, 14);
        myMap.setBounds(bounds, {checkZoomRange:true});
      })
    })
  }

}
