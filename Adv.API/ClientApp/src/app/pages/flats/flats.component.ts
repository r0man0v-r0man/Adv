import { Component, OnInit, Output, EventEmitter, ViewChild, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { FilterOptions } from 'src/app/models/filterOptions';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AdvertType } from 'src/app/models/advertType';
import { SuggestService } from 'src/app/services/suggest.service';
import { City } from 'src/app/models/city.model';
import { RentComponent } from './rent/rent.component';
import { SaleComponent } from './sale/sale.component';

@Component({
  selector: 'app-flats',
  templateUrl: './flats.component.html',
  styleUrls: ['./flats.component.less']
})
export class FlatsComponent implements OnInit, AfterViewInit {
  /** форма для выбора создаваемого объявления */
  helperForm: FormGroup;
  helper: {advertType:AdvertType; city: City}
  /** выбранный тип объявления */
  selectedAdvertType: string = AdvertType.rent;
  /** типы объявлений */
  advertTypesList: Array<{ value: string; label: string }> = [];

  isShowComponent: boolean = false;

  @ViewChild(RentComponent) private rentComponent: RentComponent;
  @ViewChild(SaleComponent) private saleComponent: SaleComponent;
  constructor(
    private formBuilder: FormBuilder,
    public suggestService: SuggestService,
    private changeDetector : ChangeDetectorRef
  ) { }
  ngAfterViewInit(): void {
    console.log('kjkjkj');
    
  }

  ngOnInit(): void {
    this.initHelperForm();

  }
  submitHelper(helperValues: {advertType:AdvertType; city: City}){    
    this.helper = {...helperValues};
    this.advertSwitcher();
    this.changeDetector.detectChanges();
     this.isShowComponent ? this.saleComponent.showAdverts(this.helper.city) : this.rentComponent.showAdverts(this.helper.city);
    
    
  }
  private advertSwitcher() {
    if (this.helper.advertType === AdvertType.rent) {
      this.isShowComponent = false
    }
    else if (this.helper.advertType === AdvertType.sale) {
      this.isShowComponent = true
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
