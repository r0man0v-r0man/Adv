import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FileService } from 'src/app/services/file.service';
import { AuthService } from 'src/app/services/auth.service';
import { StreetsService } from 'src/app/services/streets.service';
import { CompressorService } from 'src/app/services/compressor.service';
import { UploadFile } from 'ng-zorro-antd';
import { Constants } from 'src/app/constants';
import { Observable } from 'rxjs';
import { Cities } from 'src/app/models/cities';
import { Duration } from 'src/app/models/duration';
import { DescriptionValidators } from 'src/app/validators/description.validators';

@Component({
  selector: 'app-create-house-rent',
  templateUrl: './create-house-rent.component.html',
  styleUrls: ['./create-house-rent.component.less']
})
export class CreateHouseRentComponent implements OnInit {
  /** форма добавления объявления - дом сдать */
  houseRentForm: FormGroup;
  /** фото к объявлению */
  fileList : UploadFile[] = [];
  files: UploadFile[] = [];
  showUploadList = {
    showPreviewIcon: false,
    showRemoveIcon: true
  }
    
  /** uploadUrl используется в шаблоне */
  uploadUrl = Constants.uploadFileUrl;

  /** Selected City, default district is: 0 */
  selectedCity: number = 0;
  /** Array of cities */
  listOfCities: Array<{ label: string; value: number}> = [];
  /** streets */
  selectedStreet = null;
  listOfStreet: Array<{ value: string; text: string }> = [];
  nzFilterOption = () => true;

  selectedPhoneNumberPrefix:string = '+375';
  listOfPhoneNumberPrefix: Array<{ value: string; text: string }> = [];
  phoneNumber: number;
    /** count of rooms */
    rooms: number;
    /** Number of House, part of address */
  numberOfHouse: number;
  /** duration long */
  selectedDuration: number = 0;
  listOfDuration: Array<{ label: string; value: number}> = [];
  /** house's price, default is: 50 */
  price: number = 50;
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
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
  /** exist or not */
  bathhouse: boolean = false;
  /** exist or not */
  garage: boolean = false;
  constructor(
    private formBuilder: FormBuilder,
    private fileService: FileService,
    private authService: AuthService,
    private streetService: StreetsService,
    public compressor: CompressorService
  ) { }

  ngOnInit() {
    this.initHouseRentForm();
  }
  /** установка начальных значений */
  initHouseRentForm(){
    this.setPhoneNumberPrefixes();
    this.setStreets();
    this.setCities();
    this.setDurations();
    this.houseRentForm = this.formBuilder.group({
      userId: [this.authService.currentUser.sub, [Validators.required]],
      isActive: [true],
      files: [this.fileList, [Validators.required]],
      city: [this.selectedCity, [Validators.required]],
      street: [this.selectedStreet, [Validators.required]],
      numberOfHouse: [null, [Validators.required]],
      rooms: [this.rooms, [Validators.required]],
      furniture: [this.furniture],
      refrigerator: [this.refrigerator],
      microwaveOven: [this.microwaveOven],
      internet: [this.internet],
      washingMachine: [this.washingMachine],
      bathhouse: [this.bathhouse],
      garage: [this.garage],
      duration: [this.selectedDuration, [Validators.required]],
      price: [null, [Validators.required]],
      phoneNumberPrefix:[this.selectedPhoneNumberPrefix],
      phoneNumber: [ this.phoneNumber, [Validators.required, Validators.maxLength(9), Validators.minLength(9), Validators.pattern("[0-9]*")]],
      description: [null, [DescriptionValidators.notOnlySpace]]
    })
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
  /** header c JWT токеном для загрузки фото */
  headers = () => {
    return this.authService.Token;
  };
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
          this.setHouseRentFormControlValue('files', this.files);

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
  setHouseRentFormControlValue(formControlName: string, value: any){
    this.houseRentForm.controls[formControlName].setValue(value);
  };
  onChange(info: { file : UploadFile} ){
    if(info.file.status === 'done' && info.file.response) 
     
    this.files.push(info.file.response);

    this.setHouseRentFormControlValue('files', this.files);
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
