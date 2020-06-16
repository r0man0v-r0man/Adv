import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { FilterOptions } from 'src/app/models/filterOptions';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AdvertType } from 'src/app/models/advertType';
import { SuggestService } from 'src/app/services/suggest.service';
import { City } from 'src/app/models/city.model';
import { RentComponent } from './rent/rent.component';

@Component({
  selector: 'app-flats',
  templateUrl: './flats.component.html',
  styleUrls: ['./flats.component.less']
})
export class FlatsComponent implements OnInit {
  /** форма для выбора создаваемого объявления */
  helperForm: FormGroup;
  helper: {advertType:AdvertType; city: City}
  /** выбранный тип объявления */
  selectedAdvertType: string = AdvertType.rent;
  /** типы объявлений */
  advertTypesList: Array<{ value: string; label: string }> = [];

  isShowRents: boolean = false;
  isShowSales: boolean = false;

  @ViewChild(RentComponent) private rentComponent: RentComponent;
  constructor(
    private formBuilder: FormBuilder,
    public suggestService: SuggestService
  ) { }

  ngOnInit(): void {
    this.initHelperForm();
    this.isShowSales = false;
    this.isShowRents = true;

  }
  submitHelper(helperValues: {advertType:AdvertType; city: City}){    
    this.helper = {...helperValues};
    console.log(this.helper.city);
    
    this.advertSwitcher();
    this.rentComponent.showAdverts(this.helper.city);
  }
  private advertSwitcher() {
    if (this.helper.advertType === AdvertType.rent) {
      this.isShowRents = true;
      this.isShowSales = false;
    }
    else if (this.helper.advertType === AdvertType.sale) {
      this.isShowRents = false;
      this.isShowSales = true;
    }
  }
  /** инициализация формы */
  private initHelperForm(){
    this.setAdvertTypes();
    this.helperForm = this.formBuilder.group({
      advertType: [ this.selectedAdvertType ],
      city: [ null ]
    })
  }
  /** установка типов объявлений */
  private setAdvertTypes(){
    this.advertTypesList.push(
      { label: 'сдаются', value: AdvertType.rent },
      { label: 'продаются', value: AdvertType.sale }
    )
  }
}
