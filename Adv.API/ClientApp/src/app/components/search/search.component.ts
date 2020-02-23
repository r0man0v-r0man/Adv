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
    longForm: FormGroup;
     /** duration long */
  selectedDuration: number = 0;
  listOfDuration: Array<{ label: string; value: number}> = [];
  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.initLongForm();
    this.setDurations();
    this.setCities();
  }


  initLongForm(){
    this.longForm = this.formBuilder.group({
      city: [this.selectedCity, [Validators.required]],
      duration: [this.selectedDuration, [Validators.required]]
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
   * Set list of duration for select menu
   */
  setDurations(){
    this.listOfDuration.push(
      { label: 'Длительная', value: Duration.long },
      { label: 'Часы/сутки', value: Duration.short }
      );
  }
}
