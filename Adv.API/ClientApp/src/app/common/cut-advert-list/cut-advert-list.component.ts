import { Component, OnInit, Input } from '@angular/core';
import { TypeOfAdvert } from 'src/app/models/advertType';
import { AdvertLink } from 'src/app/models/advertLink.model';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'app-cut-advert-list',
  templateUrl: './cut-advert-list.component.html',
  styleUrls: ['./cut-advert-list.component.less']
})
export class CutAdvertListComponent implements OnInit {
  @Input() adverts: AdvertLink[];
  /** тип объявления */
  @Input() type: TypeOfAdvert;
  constructor(
    private AdvertService: AdvertService
  ) { }

  ngOnInit(): void {
  }
  onAdvertClick(advert: AdvertLink) {
    this.AdvertService.navigateToAdvert(advert, this.type);
  }
  edit(advert: AdvertLink) {
    console.log(advert);
  }
  delete(advert: AdvertLink) {
    this.AdvertService.delete(advert.id, this.type).subscribe(data => {
      console.log(data);
    })
  }
}
