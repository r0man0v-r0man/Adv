import { Injectable } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { EditAdvertComponent } from '../modals/edit-advert/edit-advert.component';
@Injectable()
export class ModalService {

  constructor(
    private nzModalService: NzModalService
  ) { }
  openEditModal() {
    const modal = this.nzModalService.create({
      nzTitle: 'Редакитрование объявления',
      nzContent: EditAdvertComponent,
      nzOnOk: (instance) => {
        console.log(instance);
        
      } 
    })
  }
}
