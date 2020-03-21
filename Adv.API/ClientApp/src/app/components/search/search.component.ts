import { Component, OnInit } from '@angular/core';
import { Cities } from 'src/app/models/cities';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Duration } from 'src/app/models/duration';
import { SearchFlatService } from 'src/app/services/search-flat.service';
import { SearchFlatCriteria } from 'src/app/models/searchFlatCriteria';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { NzModalService } from 'ng-zorro-antd';

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

  /** параметры поиска */
  criteria: SearchFlatCriteria = new SearchFlatCriteria();
  pageNumber: number = 1;

  /**spinner on/off  */
  isLoading: boolean = false;
  constructor(
    private formBuilder: FormBuilder,
    private searchService: SearchFlatService,
    private router: Router,
    private data: DataService,
    private modalService: NzModalService
  ) { }

  ngOnInit() {
    this.initForm();
    this.setRooms();
    this.setCities();
    this.setRentTypes();
  }


  initForm(){
    this.searchForm = this.formBuilder.group({
      city: [this.selectedCity, [Validators.required]],
      rooms: [this.selectedRoom, [Validators.required]],
      priceMin: [this.priceMin, [Validators.required]],
      priceMax: [this.priceMax, [Validators.required]],
      rentType: [this.selectedRentType, [Validators.required]],
      pageNumber: [this.pageNumber]
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
      { label: 'Трехкомнатная', value: 3 },
      { label: '4+ комнат', value: 4}
      );
  }
  submitSearchForm(){
    this.isLoading = true;
    this.criteria = this.searchForm.value;
    this.data.setSearchFields(this.criteria);
    this.searchService.findFlats(this.criteria).subscribe(response => {
      if(response && response.length != 0){
        this.data.setSearchResult(response);
        this.goToResult();
      }
      else{
        this.modalService.info({
          nzTitle: 'Мы ничего не нашли!',
          nzContent: 'Извините, по указанным параметрам сейчас нет объявлений'
        })
      }
    },
    ()=>{
      this.isLoading = false;
    },
    ()=>{
      this.isLoading = false;
    })

  }
  /** go to search result page */
  goToResult(){
    this.router.navigate(['search-result']);
  }
  
}
