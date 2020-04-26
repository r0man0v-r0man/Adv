import { Injectable } from '@angular/core';
import { Title, Meta } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root'
})
export class SeoService {

  constructor(
    private titleService: Title,
    private metaService: Meta,
  ) { }
  /** установка СЕО данных для страницы */
  setMetaInfo(data){
    if(data.title){
      this.titleService.setTitle(data.title)
    }
    if (data.description) {
      this.metaService.updateTag({ name: 'description', content: data.description })
    } else {
      this.metaService.removeTag("name='description'")
    }
    if (data.robots) {
      this.metaService.updateTag({ name: 'robots', content: data.robots })
    } else {
      this.metaService.updateTag({ name: 'robots', content: "follow,index" })
    }
  }
}
