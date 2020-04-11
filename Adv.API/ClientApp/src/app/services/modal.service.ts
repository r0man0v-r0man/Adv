import { Injectable } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd';
import { AddAdvertComponent } from '../modal/add-advert/add-advert.component';
import { AdvertType } from '../models/advertType';
import { RealEstaties } from '../models/realEstaties';
import { CreateFlatRentComponent } from '../components/createAdvert/create-flat-rent/create-flat-rent.component';
import { AdvertService } from './advert.service';
import { CreateFlatSaleComponent } from '../components/createAdvert/create-flat-sale/create-flat-sale.component';

@Injectable({
  providedIn: 'root'
})
export class ModalService {

  constructor(
    private modalService: NzModalService,
    private advertService: AdvertService
  ) { }
  advertCreateModal(){
    const modal = this.modalService.create({
      nzTitle: 'Добавить объявление',
      nzContent: AddAdvertComponent,
      nzFooter:[
        {
          type: 'primary',
          label: 'Далее',
          disabled: ()=> 
            !modal.getContentComponent().helperForm.valid,
          onClick: ()=>{
            this.nextModal(modal.getContentComponent().helperForm.value);            
            modal.destroy();
          }
        }
      ]
    });
  }
  /**
   * следующее окно исходя из полученных данных в helper
   * helper.advertType - сдать/продать и helper.realEstateType - квартира/дом
   */
  nextModal(helper: any){
    if(helper.advertType === AdvertType.rent && helper.realEstateType === RealEstaties.flat){   
      this.createFlatRentModal();
    } else 
    if(helper.advertType === AdvertType.sale && helper.realEstateType === RealEstaties.flat){
      this.createFlatSaleModal();
    } else 
    if(helper.advertType === AdvertType.rent && helper.realEstateType === RealEstaties.house){
      this.createHouseRentModal();
    } else 
    if(helper.advertType === AdvertType.sale && helper.realEstateType === RealEstaties.house){
      this.createHouseSaleModal();
    }
  }
  /** открытие модалього окна с формой добавления объявления дом продать */
  private createHouseSaleModal(){
    console.log('реализации пока нет');
    
  }
  /** открытие модалього окна с формой добавления объявления дом сдать */
  private createHouseRentModal(){
    console.log('реализации пока нет');
    
  }
  /** открытие модального окна с формой добавления объявления квартира продать */
  private createFlatSaleModal(){
    const createAdvertModal = this.modalService.create({
      nzTitle: 'Добавить объявление - квартира, продать',
      nzContent: CreateFlatSaleComponent,
      nzFooter: [{
        label: 'Добавить',
        type: 'primary',
        disabled: () => !createAdvertModal.getContentComponent().flatSaleForm.valid,
        onClick: () => {
          this.advertService.createAdvertFlatSale(createAdvertModal);
          createAdvertModal.destroy();
        }
      }]
    })
  }
  /** открытие модального окна с формой добавления объявления квартира сдать */
  private createFlatRentModal(){
    const createAdvertModal = this.modalService.create({
      nzTitle: 'Добавить объявление - квартира, сдать',
      nzContent: CreateFlatRentComponent,
      nzFooter: [{
        label: 'Добавить',
        type: 'primary',
        disabled: () => !createAdvertModal.getContentComponent().flatRentForm.valid,
        onClick: () => {
          this.advertService.createAdvertFlatRent(createAdvertModal);
          createAdvertModal.destroy();
        }
      }]
    })
  }
}
