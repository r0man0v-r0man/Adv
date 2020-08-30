import { Component, OnInit, Input } from '@angular/core';
import { TypeOfAdvert } from 'src/app/models/advertType';
import { AdvertLink } from 'src/app/models/advertLink.model';
import { AdvertService } from 'src/app/services/advert.service';
import { ModalService } from 'src/app/services/modal.service';
import { NzModalService } from 'ng-zorro-antd/modal';

@Component({
  selector: 'app-cut-advert-list',
  templateUrl: './cut-advert-list.component.html',
  styleUrls: ['./cut-advert-list.component.less'],
  providers:[
    ModalService,
    NzModalService
  ]
})
export class CutAdvertListComponent implements OnInit {
  @Input() adverts: AdvertLink[];
  /** тип объявления */
  @Input() type: TypeOfAdvert;
  constructor(
    private AdvertService: AdvertService,
    private modalService: ModalService
  ) { }

  ngOnInit(): void {
  }
  onAdvertClick(advert: AdvertLink) {
    this.AdvertService.navigateToAdvert(advert, this.type);
  }
  edit(advert: AdvertLink) {
    this.modalService.openEditModal();
  }
  delete(advert: AdvertLink) {
    this.AdvertService.delete(advert.id, this.type).subscribe(data => {
      if (data.response) {
        const index = this.adverts.indexOf(advert);
        if(index !== -1) {
          this.adverts.splice(index, 1);
        }
      }
    })
  }
}
