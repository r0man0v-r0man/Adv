import { Component, OnInit, ChangeDetectionStrategy, ViewEncapsulation } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Constants } from 'src/app/constants';
import { ImageService } from 'src/app/services/image.service';
import { Observable, BehaviorSubject, fromEvent } from 'rxjs';
import { UploadFile } from 'ng-zorro-antd/upload';
import { YandexService } from 'src/app/services/yandex.service';

@Component({
  selector: 'sale-house',
  templateUrl: './sale-house.component.html',
  styleUrls: ['./sale-house.component.less']
})
export class SaleHouseComponent implements OnInit{
  /** uploadUrl используется в шаблоне */
  uploadUrl = Constants.uploadFileUrl;
  /** header c JWT токеном для загрузки фото */
  headers = () => { return this.authService.Token; };
  /** фото к объявлению */
  imageList : UploadFile[] = [];
  images: UploadFile[] = [];
  showUploadList = { showPreviewIcon: false, showRemoveIcon: true }
  /** адрес */
 
  listOfAddresses : Array<{ displayName: string; value: string }> = [];
  /** форма */
  saleHouseForm: FormGroup;
  address: string = '';
  /** общая площадь дома */
  houseArea: number;
  /** жилая площадь дома */
  houseLiveArea: number;
  /** площадь кухни */
  kitchenArea: number;
  /** площадь участка */
  housePlotArea:number;
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
  /** цена */
  price: number = 30000;
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  /** телефон */
  phone: number = 80291234567;
  /** описание */
  description: string = '';
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    public imageService: ImageService,
    public yandexService: YandexService
  ) { }

  ngOnInit(): void {
    this.initForm();
    
  }
  initForm(){
    this.saleHouseForm = this.formBuilder.group({
      userId:[ this.authService.currentUser.sub,[Validators.required]],
      isActive: [ true ],
      images: [ this.imageList, [Validators.required]],
      address: [ this.address, [Validators.required]],
      houseArea: [ this.houseArea, [Validators.required]],
      houseLiveArea: [ this.houseLiveArea, [Validators.required]],
      kitchenArea: [ this.kitchenArea, [Validators.required] ],
      housePlotArea: [ this.housePlotArea, [Validators.required]],
      heating: [ this.heating ],
      water: [ this.water ],
      gas: [ this.gas ],
      sewage: [ this.sewage ],
      electricity: [ this.electricity ],
      bathhouse: [ this.bathhouse ],
      garage: [ this.garage ],
      price: [ null, [Validators.required]],
      phone: [ this.phone, [Validators.required, Validators.pattern("[0-9]*")]],
      description: [ null, [DescriptionValidators.notOnlySpace]]
    })
  }
  
  submitForm(){

  }
  /** Delete file */
  onDelete = (file: UploadFile) : Observable<boolean> => {
    return new Observable(observer =>{
      if(file){
        this.imageService.delete(file.response.name)
        .subscribe(response =>{
          if(response) {
            
          let index = this.images.findIndex(x=>x.uid === file.response.uid);
          
          if(index > -1) {
            this.images.splice(index, 1);
          }
          this.setHouseSaleFormControlValue('files', this.images);

          observer.next(response);
          observer.complete();
          }
        });
      }
    })
  }
  onChange(info: { file : UploadFile} ){
    if(info.file.status === 'done' && info.file.response) 
     
    this.images.push(info.file.response);

    this.setHouseSaleFormControlValue('files', this.images);
  }
  /**
   * Set value to formControl
   * @param formControlName name of form control 
   * @param value value 
   */
  private setHouseSaleFormControlValue(formControlName: string, value: any){
    this.saleHouseForm.controls[formControlName].setValue(value);
  };
}
