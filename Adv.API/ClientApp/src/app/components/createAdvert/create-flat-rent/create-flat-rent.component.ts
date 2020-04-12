import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { Constants } from 'src/app/constants';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UploadFile } from 'ng-zorro-antd';
import { FileService } from 'src/app/services/file.service';
import { AuthService } from 'src/app/services/auth.service';
import { StreetsService } from 'src/app/services/streets.service';
import { CompressorService } from 'src/app/services/compressor.service';
import { Observable } from 'rxjs';
import { UserWarning } from 'src/app/app-errors/userWarning';
import { Duration } from 'src/app/models/duration';
import { Cities } from 'src/app/models/cities';
import { DescriptionValidators } from 'src/app/validators/description.validators';

@Component({
  selector: 'app-create-flat-rent',
  templateUrl: './create-flat-rent.component.html',
  styleUrls: ['./create-flat-rent.component.less']
})
export class CreateFlatRentComponent implements OnInit {

  /** uploadUrl используется в шаблоне */
  uploadUrl = Constants.uploadFileUrl;

  /** Minimum dimension/resolution for image */
  minDimension = 250;
  /** Max file size in mb */
  maxFileSize = 5;
  /** Selected City, default district is: 0 */
  selectedCity: number = 0;
  /** Array of cities */
  listOfCities: Array<{ label: string; value: number}> = [];
  /** Flat's price, default is: 50 */
  price: number = 50;
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  /** Street, part of address */
  street: string = '';
  /** Number of House, part of address */
  numberOfHouse: number;
  /** Number of House Corpus, part of address */
  numberOfHouseCourpus: number;
  /** Number Of SubHouse, part of address */
  numberOfSubHouse: number;
  /** Number of flat, part of address */
  numberOfFlat: number;
  /** city */
  city: string;
  /** count of rooms */
  rooms: number;
  /** duration long */
  selectedDuration: number = 0;
  listOfDuration: Array<{ label: string; value: number}> = [];
  /** exist or not */
  furniture: boolean = false;
  /** exist or not */
  refrigerator: boolean = false;
  /** exist or not */
  microwaveOven: boolean = false;
  /** exist or not */
  internet:boolean = false;
  /** exist or not */
  washingMachine:boolean = false;
  /** flat floor */
  floor: number;
  /** Count all floor of house */
  allFloor?: number; 

  flatRentForm: FormGroup;
  fileList : UploadFile[] = [];
  /**file from success status from server */
  files: UploadFile[] = [];
  showUploadList = {
    showPreviewIcon: false,
    showRemoveIcon: true
  }
  /** streets */
  selectedStreet = null;
  listOfStreet: Array<{ value: string; text: string }> = [];
  nzFilterOption = () => true;

  selectedPhoneNumberPrefix:string = '+375';
  listOfPhoneNumberPrefix: Array<{ value: string; text: string }> = [];
  phoneNumber: number;

  constructor( 
    private formBuilder: FormBuilder,
    private fileService: FileService,
    private authService: AuthService,
    private streetService: StreetsService,
    public compressor: CompressorService
  ) { }

  ngOnInit() {
    this.initFlatRentForm();
  }
  headers = () => {
    return this.authService.Token;
  };
  /**
   * Initialize form fields
   */
  initFlatRentForm(){
    this.setCities();
    this.setDurations();
    this.setStreets();
    this.setPhoneNumberPrefixes();
    this.flatRentForm = this.formBuilder.group({
      userId: [this.authService.currentUser.sub, [Validators.required]],
      isActive: [true],
      price: [null, [Validators.required]],
      description: [null, [DescriptionValidators.notOnlySpace]],
      files: [this.fileList, [Validators.required]],
      city: [this.selectedCity, [Validators.required]],
      street: [this.selectedStreet, [Validators.required]],
      numberOfHouse: [null, [Validators.required]],
      numberOfHouseCourpus: [this.numberOfHouseCourpus],
      numberOfSubHouse: [ this.numberOfSubHouse],
      numberOfFlat: [this.numberOfFlat],
      floor: [this.floor, [Validators.required]],
      allFloor: [this.allFloor, [Validators.required]],
      furniture: [this.furniture],
      refrigerator: [this.refrigerator],
      microwaveOven: [this.microwaveOven],
      internet: [this.internet],
      washingMachine: [this.washingMachine],
      rooms: [this.rooms, [Validators.required]],
      duration: [this.selectedDuration, [Validators.required]],
      phoneNumberPrefix:[this.selectedPhoneNumberPrefix],
      phoneNumber: [ this.phoneNumber, [Validators.required, Validators.maxLength(9), Validators.minLength(9), Validators.pattern("[0-9]*")]]
    });
  }
  /**установка улиц для выпадающего селекта */
  setStreets(){
    this.streetService.getStreets().subscribe(response => {
      if(response){
        const listOfOption: Array<{ value: string; text: string }> = [];
        response.streets.forEach(street => {
          listOfOption.push({
            value: street.name,
            text: street.name
          });
        });
        this.listOfStreet = listOfOption;
      }
    });
  }
  /**на будущее, может другие появятся */
  setPhoneNumberPrefixes(){
    this.listOfPhoneNumberPrefix.push(
      { text: '+375', value: '+375' }
    )
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
  onChange(info: { file : UploadFile} ){
     if(info.file.status === 'done' && info.file.response) 
      
     this.files.push(info.file.response);

     this.setFlatRentFormControlValue('files', this.files);
  }
  /**
   * Delete file
   */
  onDelete = (file: UploadFile) : Observable<boolean> => {
    return new Observable(observer =>{
      if(file){
        this.fileService.deleteFile(file.response.name)
        .subscribe(response =>{
          if(response) {
            
          let index = this.files.findIndex(x=>x.uid === file.response.uid);
          
          if(index > -1) {
            this.files.splice(index, 1);
          }
          this.setFlatRentFormControlValue('files', this.files);

          observer.next(response);
          observer.complete();
          }
        });
      }
    })
  }
  /**
   * Set value to formControl
   * @param formControlName name of form control 
   * @param value value 
   */
  setFlatRentFormControlValue(formControlName: string, value: any){
    this.flatRentForm.controls[formControlName].setValue(value);
  };
}
