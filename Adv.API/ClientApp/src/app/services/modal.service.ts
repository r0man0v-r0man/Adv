import { Injectable } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { AddAdvertComponent } from '../modals/add-advert/add-advert.component';
import { AdvertType } from '../models/advertType';
import { RealEstaties } from '../models/realEstaties';
import { CreateFlatRentComponent } from '../modals/create-flat-rent/create-flat-rent.component';
import { AdvertService } from './advert.service';
import { CreateFlatSaleComponent } from '../modals/create-flat-sale/create-flat-sale.component';
import { CreateHouseRentComponent } from '../modals/create-house-rent/create-house-rent.component';
import { CreateHouseSaleComponent } from '../modals/create-house-sale/create-house-sale.component';
@Injectable({
  providedIn: 'root'
})
export class ModalService {

  constructor(
    private nzModalService: NzModalService,
    private advertService: AdvertService
  ) { }
  advertCreateModal(){
    const modal = this.nzModalService.create({
      nzTitle: 'Добавить объявление',
      nzContent: AddAdvertComponent,
      nzFooter:[
        {
          label: 'Отмена',
          type: 'link',
          onClick: () => {
            modal.destroy();
          }
        },
        {
          type: 'primary',
          label: 'Далее',
          disabled: () => !modal.getContentComponent().helperForm.valid,
          onClick: ()=> {
            this.nextModal(modal.getContentComponent().helperForm.value);            
            modal.destroy();
          }
        }
      ]
    })
  }
  /**
   * следующее окно исходя из полученных данных в helper
   * helper.advertType - сдать/продать и helper.realEstateType - квартира/дом
   */
  private nextModal(helper: any){
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
  /** открытие модального окна с формой добавления объявления квартира сдать */
  private createFlatRentModal(){
    const modal = this.nzModalService.create({
      nzTitle: 'Добавить объявление - квартира, сдать',
      nzContent: CreateFlatRentComponent,
      nzFooter: [
        {
          label: 'Отмена',
          type: 'link',
          onClick: () => {
            modal.destroy();
          }
        },
        {
          label: 'Назад',
          type: 'dashed',
          onClick: () => {
            this.advertCreateModal();
            modal.destroy();
          }
        },
        {
          label: 'Добавить',
          disabled: () => !modal.getContentComponent().flatRentForm.valid,
          onClick: () => {
            this.advertService.createAdvertFlatRent(modal);
            modal.destroy();
          }
        }
      ]
    })
  }
  /** открытие модального окна с формой добавления объявления квартира продать */
  private createFlatSaleModal(){
    const modal = this.nzModalService.create({
      nzTitle: 'Добавить объявление - квартира, продать',
      nzContent: CreateFlatSaleComponent,
      nzFooter: [
        {
          label: 'Отмена',
          type: 'link',
          onClick: () => {
            modal.destroy();
          }
        },
        {
          label: 'Назад',
          type: 'dashed',
          onClick: () => {
            this.advertCreateModal();
            modal.destroy();
          }
        },
        {
          label: 'Добавить',
          disabled: () => !modal.getContentComponent().flatSaleForm.valid,
          onClick: () => {
            this.advertService.createAdvertFlatSale(modal);
            modal.destroy();
          }
        }
      ]
    })
  }
  /** открытие модалього окна с формой добавления объявления дом сдать */
  private createHouseRentModal(){
    const modal = this.nzModalService.create({
      nzTitle: 'Добавить объявление - дом, сдать',
      nzContent: CreateHouseRentComponent,
      nzFooter: [
        {
          label: 'Отмена',
          type: 'link',
          onClick: () => {
            modal.destroy();
          }
        },
        {
          label: 'Назад',
          type: 'dashed',
          onClick: () => {
            this.advertCreateModal();
            modal.destroy();
          }
        },
        {
          label: 'Добавить',
          disabled: () => !modal.getContentComponent().houseRentForm.valid,
          onClick: () => {
            this.advertService.createAdvertHouseRent(modal);
            modal.destroy();
          }
        }
      ]
    })
  }
  /** открытие модалього окна с формой добавления объявления дом продать */
  private createHouseSaleModal(){
    const modal = this.nzModalService.create({
      nzTitle: 'Добавить объявление - дом, продать',
      nzContent: CreateHouseSaleComponent,
      nzFooter: [
        {
          label: 'Отмена',
          type: 'link',
          onClick: () => {
            modal.destroy();
          }
        },
        {
          label: 'Назад',
          type: 'dashed',
          onClick: () => {
            this.advertCreateModal();
            modal.destroy();
          }
        },
        {
          label: 'Добавить',
          disabled: () => !modal.getContentComponent().houseSaleForm.valid,
          onClick: () => {
            this.advertService.createAdvertHouseSale(modal);
            modal.destroy();
          }
        }
      ]
    })
  }
}
