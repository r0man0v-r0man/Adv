import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AdvertType } from 'src/app/models/advertType';
import { FilterOptions } from 'src/app/models/filterOptions';

@Component({
  selector: 'app-houses',
  templateUrl: './houses.component.html',
  styleUrls: ['./houses.component.less']
})
export class HousesComponent implements OnInit {
  /** форма для выбора создаваемого объявления */
  helperForm: FormGroup;
  helper: { advertType: string; };
  /** выбранный тип объявления */
  selectedAdvertType: string = AdvertType.sale;
  /** типы объявлений */
  advertTypesList: Array<{ value: string; label: string }> = [];

  isShowRents: boolean = false;
  isShowSales: boolean = false;

  filterOption: FilterOptions;

  constructor(
    private formBuilder: FormBuilder

  ) { }

  ngOnInit(): void {
    this.initHelperForm();
    this.getHelperFormValues();
    this.filterOption = this.setFilterOption();
  }
  /** получение значений формы */
  private getHelperFormValues() {
    this.helperForm.valueChanges.subscribe(() => {
      this.helper = { ...this.helperForm.value };
      this.advertSwitcher();
    })
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
      advertType: [ this.selectedAdvertType ]
    })
  }
  /** установка типов объявлений */
  private setAdvertTypes(){
    this.advertTypesList.push(
      { label: 'сдаются', value: AdvertType.rent },
      { label: 'продаются', value: AdvertType.sale }
    )
  }
  private setFilterOption(): FilterOptions {
    return {
      pageNumber: 1
    };
  }
}
