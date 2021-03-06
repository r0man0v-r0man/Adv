import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import {FormGroup, FormBuilder} from '@angular/forms';
import { AdvertType } from 'src/app/models/advertType';
import { RentComponent } from './rent/rent.component';
import { SaleComponent } from './sale/sale.component';
import { IComponent } from 'src/app/models/yandex';

@Component({
  selector: 'app-houses',
  templateUrl: './houses.component.html',
  styleUrls: ['./houses.component.less']
})
export class HousesComponent implements OnInit {
  /** форма для выбора создаваемого объявления */
  helperForm: FormGroup;
  helper: {advertType: AdvertType; province: IComponent};
  /** выбранный тип объявления */
  selectedAdvertType: string = AdvertType.sale;
  /** типы объявлений */
  advertTypesList: Array<{ value: string; label: string }> = [];

  isShowComponent = true;

  @ViewChild(RentComponent) private rentComponent: RentComponent;
  @ViewChild(SaleComponent) private saleComponent: SaleComponent;

  constructor(
    private formBuilder: FormBuilder,
    private changeDetector: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.initHelperForm();
    this.submitHelper(this.helperForm.value);
  }
  submitHelper(helperValues: {advertType: AdvertType; province: IComponent}) {
    this.helper = {...helperValues};
    this.advertSwitcher();
    this.changeDetector.detectChanges();
    this.isShowComponent ? this.saleComponent.showAdverts(this.helper.province) : this.rentComponent.showAdverts(this.helper.province);
  }
  /** переключение типов объявлений сдать/продать */
  private advertSwitcher() {
    if (this.helper.advertType === AdvertType.rent) {
      this.isShowComponent = false;
    } else if (this.helper.advertType === AdvertType.sale) {
      this.isShowComponent = true;
    }
  }
  /** инициализация формы */
  private initHelperForm() {
    this.setAdvertTypes();
    this.helperForm = this.formBuilder.group({
      advertType: [ this.selectedAdvertType ],
      province: [ null ]
    });
  }
  /** установка типов объявлений */
  private setAdvertTypes() {
    this.advertTypesList.push(
      { label: 'сдаются', value: AdvertType.rent },
      { label: 'продаются', value: AdvertType.sale }
    );
  }

}
