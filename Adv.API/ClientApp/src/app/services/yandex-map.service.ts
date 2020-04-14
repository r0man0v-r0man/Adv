import { Injectable } from '@angular/core';
import ymaps from 'ymaps';

@Injectable({
  providedIn: 'root'
})
export class YandexMapService {
  myMap;
  mapExist: boolean;
  constructor() { }
  /** подсказка от яндекс карт API при вводе адреса */
  createSuggest(htmlContainerId: string){
      ymaps.load("https://api-maps.yandex.ru/2.1/?apikey=85e03f02-25be-40b3-971e-733f2a03e620&lang=ru_RU")
      .then(maps => {
        let suggestView = new maps.SuggestView(htmlContainerId);
      })
  }
/**отрабатывает только при обновлении страницы - баг */
  createMap(city: string, address: string, htmlContainerId:string){
    ymaps.load("https://api-maps.yandex.ru/2.1/?apikey=85e03f02-25be-40b3-971e-733f2a03e620&lang=ru_RU")
    .then(maps => {      
  
      maps.geocode(city + ' ' + address)
        .then((res)=>{
          if(!this.mapExist){
            this.myMap = new maps.Map(htmlContainerId, {
              center: res.geoObjects.get(0).geometry.getCoordinates(),
              zoom : 14
            });
            var firstGeoObject = res.geoObjects.get(0);  
                 
            var bounds = firstGeoObject.properties.get("boundedBy");
            firstGeoObject.options.set("preset", "islands#darkBlueDotIconWithCaption");
            firstGeoObject.properties.set("iconCaption", firstGeoObject.getAddressLine());
            this.myMap.geoObjects.add(firstGeoObject)
            
            this.myMap.setBounds(bounds);
            this.mapExist = true;
          }
          else {
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
}
