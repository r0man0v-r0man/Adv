import { Component, OnInit } from '@angular/core';
import { AdvertType } from 'src/app/models/advertType';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RealEstaties } from 'src/app/models/realEstaties';

@Component({
  selector: 'app-create-advert',
  templateUrl: './create-advert.component.html',
  styleUrls: ['./create-advert.component.less']
})
export class CreateAdvertComponent implements OnInit {
  helperForm: FormGroup;
  /** выбранный тип объявления */
  selectedAdvertType: string = AdvertType.rent;
  /** типы объявлений */
  advertTypesList: Array<{ value: string; label: string }> = [];
  /** выбранный тип недвижимости */
  selectedRealEstate = RealEstaties.flat;
  /** типы недвижимости */
  listOfRealEstaties: Array<{ value: string; label: string }> = [];
  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initHelperForm();
  }
  submitHelperForm(){
    console.log(this.helperForm.value);
    
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
