import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { ImageService } from 'src/app/services/image.service';
import { Observable } from 'rxjs';
import { UploadFile, UploadChangeParam } from 'ng-zorro-antd/upload';
import { DescriptionValidators } from '../../validators/description.validators';
import { SuggestService } from 'src/app/services/suggest.service';
import { HouseSaleModel } from 'src/app/models/house-sale.model';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'sale-house',
  templateUrl: './sale-house.component.html',
  styleUrls: ['./sale-house.component.less']
})
export class SaleHouseComponent implements OnInit{
  /** фото к объявлению */
  imageList : UploadFile[] = [];
  images: UploadFile[] = [];
  showUploadList = { showPreviewIcon: false, showRemoveIcon: true }
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
  phone: string = '80291234567';
  /** описание */
  description: string = '';
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    public imageService: ImageService,
    public suggestService: SuggestService,
    private advertService: AdvertService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.initForm();
  }
  initForm(){
    this.saleHouseForm = this.formBuilder.group({
      userId:[ this.authService.currentUser.sub,[Validators.required]],
      isActive: [ true ],
      images: [ this.images , [Validators.required]],
      address: [ null, [Validators.required]],
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
    const advert: HouseSaleModel = { ...this.saleHouseForm.value }
    this.advertService.addHouseSale(advert);
  }
  /** загрузка картинки */
  onUploadChange(info:  UploadChangeParam ){
    this.imageService.handleChange(info).subscribe(response => {
      this.images = response;
      this.setHouseSaleFormControlValue('images',this.images);
      this.cd.detectChanges();
    })
  }
  /** Delete file */
  onDelete = (file: UploadFile) : Observable<boolean> => {
    return new Observable(observer =>{
      if(file){
        this.imageService.delete(file.response.deleteHash)
        .subscribe(response =>{
          if(response) {
            
          let index = this.images.findIndex(x=>x.uid === file.response.uid);
          
          if(index > -1) {
            this.images.splice(index, 1);
          }
          this.setHouseSaleFormControlValue('images', this.images);
          observer.next(response);
          observer.complete();
          }
        });
      }
    })
  }

  /**
   * установка значения для поля формы
   * @param formControlName имя поля 
   * @param value значение 
   */
  private setHouseSaleFormControlValue(formControlName: string, value: any){
    this.saleHouseForm.controls[formControlName].setValue(value);
  };
}
