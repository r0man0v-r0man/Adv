import { Injectable } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { EditAdvertComponent } from '../modals/edit-advert/edit-advert.component';
import { TypeOfAdvert } from '../models/advertType';
import { AdvertService } from './advert.service';
@Injectable()
export class ModalService {

  constructor(
    private nzModalService: NzModalService,
    private advertService: AdvertService
  ) { }
  openEditModal(id: number, type: TypeOfAdvert) {
    const modal = this.nzModalService.create({
      nzTitle: 'Редакитрование объявления',
      nzContent: EditAdvertComponent,
      nzComponentParams: {
        advertId: id,
        advertType: type 
      },
      nzOnOk: (instance) => {
        const updateModel = { 
          ...instance.form.value 
        };
        this.advertService.updateAdvert(updateModel, instance.advertId, instance.advertType)
      } 
    })
  }
}
