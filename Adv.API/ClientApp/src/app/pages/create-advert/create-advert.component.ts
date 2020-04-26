import { Component, OnInit } from '@angular/core';
import { AdvertType } from 'src/app/models/advertType';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RealEstaties } from 'src/app/models/realEstaties';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-create-advert',
  templateUrl: './create-advert.component.html',
  styleUrls: ['./create-advert.component.less']
})
export class CreateAdvertComponent implements OnInit {
  /** форма для выбора создаваемого объявления */
  helperForm: FormGroup;
  helper: { advertType: string; realEstateType: string } = {advertType: '', realEstateType: ''};
  /** выбранный тип объявления */
  selectedAdvertType: string = AdvertType.rent;
  /** типы объявлений */
  advertTypesList: Array<{ value: string; label: string }> = [];
  /** выбранный тип недвижимости */
  selectedRealEstate = RealEstaties.flat;
  /** типы недвижимости */
  listOfRealEstaties: Array<{ value: string; label: string }> = [];

  /** форма - сдать квартиру */
  rentFlatForm: FormGroup;
  /** форма - сдать дом */
  rentHouseForm: FormGroup;
  /** форма - продать квартиру */
  saleFlatForm: FormGroup;
  /** форма - продать дом */
  saleHouseForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.initHelperForm();
  }
  submitHelperForm(){   
    this.helper = { ...this.helperForm.value };
    this.initCreateAdvertForm(this.helper);
  }
  /** выбираем какую форму показывать */
  private initCreateAdvertForm(helper:{ advertType: string; realEstateType: string }){
    if(helper.advertType === AdvertType.rent) this.initCreateRentForms(helper.realEstateType);
    if(helper.advertType === AdvertType.sale) this.initCreateSaleForms(helper.realEstateType);
  }
  /** инициализация формы для аренды */
  private initCreateRentForms(realEstateType: string){
    if (realEstateType === RealEstaties.flat) this.initRentFlat();
    if (realEstateType === RealEstaties.house) this.initRentHouse();
  }
  /** инициализация формы для продажи */
  private initCreateSaleForms(realEstateType:string){
    if (realEstateType === RealEstaties.flat) this.initSaleFlat();
    if (realEstateType === RealEstaties.house) this.initSaleHouse();
  }
  /** форма объявления сдать квартиру */
  private initRentFlat(){
    this.rentFlatForm = this.formBuilder.group({
      userId: [this.authService.currentUser.sub, [Validators.required]],
    })    
  }
  /** форма объявления сдать дом */
  private initRentHouse(){
    console.log('в работе форма объявления сдать дом');
    
  }
  /** форма объявления продать квартиру */
  private initSaleFlat(){
    console.log('в работе форма объявления продать квартиру');
    
  }
  /** форма объявления продать дом */
  private initSaleHouse(){
    console.log('в работе форма объявления продать дом');
    
  }
  private initHelperForm(){
    this.setAdvertTypes();
    this.setListOfRealEstaties();
    this.helperForm = this.formBuilder.group({
      advertType: [ this.selectedAdvertType, [Validators.required]],
      realEstateType: [ this.selectedRealEstate, [Validators.required]]  
    })
  }
  /** установка типов объявлений */
  private setAdvertTypes(){
    this.advertTypesList.push(
      { label: 'Сдать', value: AdvertType.rent },
      { label: 'Продать', value: AdvertType.sale }
    )
  }
  /** установка типов недвижимости */
  private setListOfRealEstaties(){
    this.listOfRealEstaties.push(
      { value: RealEstaties.flat, label: 'Квартира' },
      { value: RealEstaties.house, label: 'Дом' }
    )
  }
}
