import { Component, OnInit, OnChanges } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FileService } from 'src/app/services/file.service';
import { AuthService } from 'src/app/services/auth.service';
import { CompressorService } from 'src/app/services/compressor.service';
import { Constants } from 'src/app/constants';
import { UploadFile } from 'ng-zorro-antd';
import { Observable } from 'rxjs';
import { DescriptionValidators } from 'src/app/validators/description.validators';
import { YandexMapService } from 'src/app/services/yandex-map.service';

@Component({
  selector: 'app-create-house-sale',
  templateUrl: './create-house-sale.component.html',
  styleUrls: ['./create-house-sale.component.less']
})
export class CreateHouseSaleComponent implements OnInit  {
  /** форма добавления объявления - дом продать */
  houseSaleForm: FormGroup;  
  /** uploadUrl используется в шаблоне */
  uploadUrl = Constants.uploadFileUrl;
  /** фото к объявлению */
  fileList : UploadFile[] = [];
  files: UploadFile[] = [];
  showUploadList = {
    showPreviewIcon: false,
    showRemoveIcon: true
  }

  selectedPhoneNumberPrefix:string = '+375';
  listOfPhoneNumberPrefix: Array<{ value: string; text: string }> = [];
  phoneNumber: number;
  /** count of rooms */
  rooms: number;
  /** Number of House, part of address */
  numberOfHouse: number;
  /** общая площадь дома */
  houseArea: number;
  /** жилая площадь дома */
  houseLiveArea: number;
  /** площадь кухни */
  kitchenArea: number;
  /** площадь участка */
  housePlot:number;
  /** отопление */
  heating: boolean = false;
  /** вода */
  water:boolean = false;
  /** газ */
  gas:boolean = false;
  /** канализация */
  sewage:boolean = false;
  /** электричество */
  electricity: boolean = false;
  /** баня */
  bathhouse:boolean = false;
  /** гараж */
  garage: boolean = false;
    /** Flat's price, default is: 50 */
    price: number = 30000;
    formatterDollar = (value: number) => `$ ${value}`;
    parserDollar = (value: string) => value.replace('$ ', '');
    selectedAddress = null;
    listOfAdresses: Array<{ displayName: string; value: string }> = [];
    nzFilterOption = () => true;
    
  constructor(
    private formBuilder: FormBuilder,
    private fileService: FileService,
    private authService: AuthService,
    public compressor: CompressorService,
    public yandexService: YandexMapService
  ) { }

  ngOnInit() {
    this.initHouseSaleForm();
  }
  onSearchAddress(value: string){
    if(value.length > 0){
      this.yandexService.getSuggests(value);
      console.log(this.yandexService.listOfAdresses);
      this.listOfAdresses = this.yandexService.listOfAdresses;
    }
    
    
  }
  initHouseSaleForm(){
    this.setPhoneNumberPrefixes();
    this.houseSaleForm = this.formBuilder.group({
      userId: [this.authService.currentUser.sub, [Validators.required]],
      isActive: [true],
      files: [this.fileList, [Validators.required]],
      address: [this.selectedAddress, [Validators.required]],
      rooms: [this.rooms, [Validators.required]],
      houseArea: [this.houseArea, [Validators.required]],
      houseLiveArea: [this.houseLiveArea, [Validators.required]],
      kitchenArea: [this.kitchenArea, [Validators.required]],
      housePlot: [this.housePlot, [Validators.required]],
      heating: [this.heating],
      water: [this.water],
      gas: [this.gas],
      sewage: [this.sewage],
      electricity: [this.electricity],
      bathhouse: [this.bathhouse],
      garage: [this.garage],
      price: [null, [Validators.required]],
      phoneNumberPrefix:[this.selectedPhoneNumberPrefix],
      phoneNumber: [ this.phoneNumber, [Validators.required, Validators.maxLength(9), Validators.minLength(9), Validators.pattern("[0-9]*")]],
      description: [null, [DescriptionValidators.notOnlySpace]]
    })
  }

  /**на будущее, может другие появятся */
  setPhoneNumberPrefixes(){
    this.listOfPhoneNumberPrefix.push(
      { text: '+375', value: '+375' }
    )
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
          this.setHouseSaleFormControlValue('files', this.files);

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
  setHouseSaleFormControlValue(formControlName: string, value: any){
    this.houseSaleForm.controls[formControlName].setValue(value);
  };
  onChange(info: { file : UploadFile} ){
    if(info.file.status === 'done' && info.file.response) 
     
    this.files.push(info.file.response);

    this.setHouseSaleFormControlValue('files', this.files);
 }
}
