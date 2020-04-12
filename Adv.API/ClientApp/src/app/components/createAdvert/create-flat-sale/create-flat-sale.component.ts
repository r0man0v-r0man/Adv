import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { FileService } from 'src/app/services/file.service';
import { StreetsService } from 'src/app/services/streets.service';
import { CompressorService } from 'src/app/services/compressor.service';
import { DescriptionValidators } from 'src/app/validators/description.validators';
import { UploadFile } from 'ng-zorro-antd';
import { Constants } from 'src/app/constants';
import { Observable } from 'rxjs';
import { UserWarning } from 'src/app/app-errors/userWarning';
import { Cities } from 'src/app/models/cities';

@Component({
  selector: 'app-create-flat-sale',
  templateUrl: './create-flat-sale.component.html',
  styleUrls: ['./create-flat-sale.component.less']
})
export class CreateFlatSaleComponent implements OnInit {
  /** форма добавления объявления - квартира продать */
  flatSaleForm: FormGroup;
  /** фото к объявлению */
  fileList : UploadFile[] = [];
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

  /** flat floor */
  floor: number;
  /** Count all floor of house */
  allFloor?: number; 
  
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
  price: number = 30000;
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
  /** площадь квартиры */
  flatArea: number;
  /** жилая площадь */
  flatLiveArea: number;
  /** площадь кухни */
  kitchenArea: number;
  /** балкон */
  selectedBalcony: number = 1;
  listOfBalcony: Array<{ label: string, value: number }> = [];
  /** санузел */
  selectedToilet: number = 1;
  listOfToilet: Array<{ label: string, value: number }> = [];
  constructor(
    private formBuilder: FormBuilder,
    private fileService: FileService,
    private authService: AuthService,
    private streetService: StreetsService,
    public compressor: CompressorService
  ) { }

  ngOnInit() {
    this.initFlatSaleForm();
  }
  /** init form for flat sale */
  initFlatSaleForm(){
    this.setCities();
    this.setStreets();
    this.setListOfBalcony();
    this.setListOfToilet();
    this.setPhoneNumberPrefixes();
    this.flatSaleForm = this.formBuilder.group({
      userId: [this.authService.currentUser.sub, [Validators.required]],
      isActive: [true],
      files: [this.fileList, [Validators.required]],
      city: [this.selectedCity, [Validators.required]],
      street: [this.selectedStreet, [Validators.required]],
      price: [null, [Validators.required]],
      numberOfHouse: [null, [Validators.required]],
      numberOfHouseCourpus: [this.numberOfHouseCourpus],
      numberOfSubHouse: [ this.numberOfSubHouse],
      numberOfFlat: [this.numberOfFlat],
      floor: [this.floor, [Validators.required]],
      allFloor: [this.allFloor, [Validators.required]],
      rooms: [this.rooms, [Validators.required]],
      flatArea: [ null, [Validators.required]],
      flatLiveArea: [ null, [Validators.required]],
      kitchenArea: [ null, [Validators.required]],
      balcony: [ this.selectedBalcony, [Validators.required]],
      toilet: [ this.selectedToilet, [Validators.required]],
      phoneNumberPrefix:[this.selectedPhoneNumberPrefix],
      phoneNumber: [ this.phoneNumber, [Validators.required, Validators.maxLength(9), Validators.minLength(9), Validators.pattern("[0-9]*")]],
      description: [null, [DescriptionValidators.notOnlySpace]]
    })
  }
  headers = () => {
    return this.authService.Token;
  };
  setListOfToilet(){
    this.listOfToilet.push(
      { label: 'Раздельный', value: 0 },
      { label: 'Совмещенный', value: 1 }
    )
  }
  setListOfBalcony(){
    this.listOfBalcony.push(
      { label: 'Есть', value: 1 },
      { label: 'Нет', value: 0 }
    )
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
  onChange(info: { file : UploadFile} ){
    if(info.file.status === 'done' && info.file.response) 
     
    this.files.push(info.file.response);

    this.setFlatSaleFormControlValue('files', this.files);
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
          this.setFlatSaleFormControlValue('files', this.files);

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
  setFlatSaleFormControlValue(formControlName: string, value: any){
    this.flatSaleForm.controls[formControlName].setValue(value);
  };
}
