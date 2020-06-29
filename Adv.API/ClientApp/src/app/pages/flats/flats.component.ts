import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import { AdvertType } from 'src/app/models/advertType';
import { SuggestService } from 'src/app/services/suggest.service';
import { City } from 'src/app/models/city.model';
import { RentComponent } from './rent/rent.component';
import { SaleComponent } from './sale/sale.component';

@Component({
  selector: 'app-flats',
  templateUrl: './flats.component.html',
  styleUrls: ['./flats.component.less'],
  providers: [
    SuggestService
  ]
})
export class FlatsComponent implements OnInit {
  /** форма для выбора создаваемого объявления */
  helperForm: FormGroup;
  helper: {advertType: AdvertType; city: City};
  /** выбранный тип объявления */
  selectedAdvertType: string = AdvertType.rent;
  /** типы объявлений */
  advertTypesList: Array<{ value: string; label: string }> = [];

  isShowComponent = false;

  @ViewChild(RentComponent) private rentComponent: RentComponent;
  @ViewChild(SaleComponent) private saleComponent: SaleComponent;
  constructor(
    private formBuilder: FormBuilder,
    public suggestService: SuggestService,
    private changeDetector: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.initHelperForm();
    this.submitHelper(this.helperForm.value);
  }
  submitHelper(helperValues: {advertType: AdvertType; city: City}) {
    this.helper = {...helperValues};
    this.advertSwitcher();
    this.changeDetector.detectChanges();
    if (this.isShowComponent) {
      this.saleComponent.listFlatSale = [];
      this.saleComponent.showAdverts(this.helper.city);
    } else {
      this.rentComponent.listFlatRent = [];
      this.rentComponent.showAdverts(this.helper.city);
    }
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
      city: [ null ]
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
