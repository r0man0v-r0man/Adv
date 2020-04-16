import { Injectable } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd';
import { AddAdvertComponent } from '../modal/add-advert/add-advert.component';
import { AdvertType } from '../models/advertType';
import { RealEstaties } from '../models/realEstaties';
import { CreateFlatRentComponent } from '../components/createAdvert/create-flat-rent/create-flat-rent.component';
import { AdvertService } from './advert.service';
import { CreateFlatSaleComponent } from '../components/createAdvert/create-flat-sale/create-flat-sale.component';
import { CreateHouseRentComponent } from '../components/createAdvert/create-house-rent/create-house-rent.component';
import { CreateHouseSaleComponent } from '../components/createAdvert/create-house-sale/create-house-sale.component';

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
          label: 'Отмена',
          type: 'link',
          onClick: ()=>{
            modal.destroy();
          }
        },
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
    const createAdvertModal = this.modalService.create({
      nzTitle: 'Добавить объявление - дом, продать',
      nzContent: CreateHouseSaleComponent,
      nzFooter:[
        {
          label: 'Отмена',
          onClick: ()=>{
            createAdvertModal.destroy();
          }
        },
        {
          label: 'Назад',
          onClick: ()=>{
            this.advertCreateModal();
            createAdvertModal.destroy();
          }
        },
        {
          label: 'Добавить',
          disabled: () => !createAdvertModal.getContentComponent().houseSaleForm.valid,
          onClick: () => {
            this.advertService.createAdvertHouseSale(createAdvertModal);
            createAdvertModal.destroy();
          }
      }]
    })    
  }
  /** открытие модалього окна с формой добавления объявления дом сдать */
  private createHouseRentModal(){
    const createAdvertModal = this.modalService.create({
      nzTitle: 'Добавить объявление - дом, сдать',
      nzContent: CreateHouseRentComponent,
      nzFooter:[
        {
          label: 'Отмена',
          onClick: ()=>{
            createAdvertModal.destroy();
          }
        },
        {
          label: 'Назад',
          onClick: ()=>{
            this.advertCreateModal();
            createAdvertModal.destroy();
          }
        },
        {
          label: 'Добавить',
          type: 'primary',
          disabled: () => !createAdvertModal.getContentComponent().houseRentForm.valid,
          onClick: () => {
            this.advertService.createAdvertHouseRent(createAdvertModal);
            createAdvertModal.destroy();
          }
      }]
    })
    
  }
  /** открытие модального окна с формой добавления объявления квартира продать */
  private createFlatSaleModal(){
    const createAdvertModal = this.modalService.create({
      nzTitle: 'Добавить объявление - квартира, продать',
      nzContent: CreateFlatSaleComponent,
      nzFooter: [
        {
          label: 'Отмена',
          onClick: ()=>{
            createAdvertModal.destroy();
          }
        },
        {
          label: 'Назад',
          onClick: ()=>{
            this.advertCreateModal();
            createAdvertModal.destroy();
          }
        },
        {
        label: 'Добавить',
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
      nzFooter: [
        {
          label: 'Отмена',
          onClick: ()=>{
            createAdvertModal.destroy();
          }
        },
        {
          label: 'Назад',
          onClick: ()=>{
            this.advertCreateModal();
            createAdvertModal.destroy();
          }
        },
        {
        label: 'Добавить',
        disabled: () => !createAdvertModal.getContentComponent().flatRentForm.valid,
        onClick: () => {
          this.advertService.createAdvertFlatRent(createAdvertModal);
          createAdvertModal.destroy();
        }
      }]
    })
  }
}
