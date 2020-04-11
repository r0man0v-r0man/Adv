import { Component, OnInit, ViewChild, AfterViewChecked } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AdvertType } from 'src/app/models/advertType';
import { RealEstaties } from 'src/app/models/realEstaties';
import { CreateFlatRentComponent } from 'src/app/components/createAdvert/create-flat-rent/create-flat-rent.component';
import { CreateFlatSaleComponent } from 'src/app/components/createAdvert/create-flat-sale/create-flat-sale.component';

@Component({
  selector: 'app-add-advert',
  templateUrl: './add-advert.component.html',
  styleUrls: ['./add-advert.component.less']
})
export class AddAdvertComponent implements OnInit {
  isValid: boolean;
  selectedAdvertType: string = AdvertType.rent.toString();
  advertTypesList: Array<{ value: string; label: string }> = [];

  selectedRealEstate = RealEstaties.flat.toString();
  listOfRealEstaties: Array<{ value: string; label: string }> = [];
  helperForm: FormGroup;

  @ViewChild(CreateFlatRentComponent, { static: false}) 
    createFlatRent:CreateFlatRentComponent;
    
  @ViewChild(CreateFlatSaleComponent, { static: false}) 
    createFlatSale:CreateFlatSaleComponent;
  constructor(
    private formBuilder: FormBuilder,
    ) { }

  ngOnInit() {
    this.initHelperForm();
  }
  /** инициализация формы выбора типа объявления, продажа/сдача, дом/квартира */
  initHelperForm(){
    this.setAdvertTypes();
    this.setListOfRealEstaties();
    this.helperForm = this.formBuilder.group({
      advertType: [this.selectedAdvertType],
      realEstateType: [this.selectedRealEstate],
    })
  }

  setListOfRealEstaties(){
    this.listOfRealEstaties.push(
      { value: RealEstaties.flat.toString(), label: 'Квартиру' },
      { value: RealEstaties.house.toString(), label: 'Дом' }
    )
  }
  
  setAdvertTypes(){
    this.advertTypesList.push(
      { label: 'Сдать', value: AdvertType.rent },
      { label: 'Продать', value: AdvertType.sale }
    )
  }
  
  
}