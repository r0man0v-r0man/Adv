import { Component, OnInit } from '@angular/core';
import { Cities } from 'src/app/models/cities';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Duration } from 'src/app/models/duration';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.less']
})
export class SearchComponent implements OnInit {

    /** Selected City, default district is: 0 */
    selectedCity: number = 0;
    /** Array of cities */
    listOfCities: Array<{ label: string; value: number}> = [];
    searchForm: FormGroup;
     /** rooms  */
  selectedRoom: number = 1;
  listOfRooms: Array<{ label: string; value: number}> = [];
  priceMin: number = 100;
  priceMax: number = 200;
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');

  selectedRentType: number = 0;
  listOfRentType: Array<{ label: string; value: number}> = [];

  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.initLongForm();
    this.setRooms();
    this.setCities();
    this.setRentTypes();
  }


  initLongForm(){
    this.searchForm = this.formBuilder.group({
      city: [this.selectedCity, [Validators.required]],
      rooms: [this.selectedRoom, [Validators.required]],
      priceMin: [this.priceMin, [Validators.required]],
      priceMax: [this.priceMax, [Validators.required]],
      rentType: [this.selectedRentType, [Validators.required]]
    })
  }
    /**
   * Set list of districts for select menu
   */
  setCities(){
    this.listOfCities.push(
      { label: 'Несвиж', value: Cities.nesvizh }
      );
  }
        /**
   * Set list of rooms for select menu
   */
  setRentTypes(){
    this.listOfRentType.push(
      { label: 'Длительная', value: Duration.long },
      { label: 'Часы/сутки', value: Duration.short }
      );
  }
      /**
   * Set list of rooms for select menu
   */
  setRooms(){
    this.listOfRooms.push(
      { label: 'Однокомнатная', value: 1 },
      { label: 'Двухкомнатная', value: 2 },
      { label: 'Трехкомнатная', value: 3 }
      );
  }
  submitSearchForm(searchForm: any){
    
  }
}
