import { Component, OnInit } from '@angular/core';
import { FilterOptions } from 'src/app/models/filterOptions';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AdvertType } from 'src/app/models/advertType';

@Component({
  selector: 'app-flats',
  templateUrl: './flats.component.html',
  styleUrls: ['./flats.component.less']
})
export class FlatsComponent implements OnInit {
  /** форма для выбора создаваемого объявления */
  helperForm: FormGroup;
  helper: { advertType: string; };
  /** выбранный тип объявления */
  selectedAdvertType: string = AdvertType.rent;
  /** типы объявлений */
  advertTypesList: Array<{ value: string; label: string }> = [];

  isShowFlatRents: boolean = false;
  isShowFlatSales: boolean = false;

  filterOption: FilterOptions;

  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initHelperForm();
    this.getHelperFormValues();
    this.filterOption = this.setFilterOption();
    this.isShowFlatSales = true;
    this.isShowFlatRents = false;
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
      this.isShowFlatRents = true;
      this.isShowFlatSales = false;
    }
    else if (this.helper.advertType === AdvertType.sale) {
      this.isShowFlatRents = false;
      this.isShowFlatSales = true;
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
      pageNumber: 1,
      city: {
        id: 15276,
        name: "Несвиж"
      }
    };
  }
}
