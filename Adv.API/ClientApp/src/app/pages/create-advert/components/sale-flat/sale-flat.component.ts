import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { AdvertService } from 'src/app/services/advert.service';
import { ImageService } from 'src/app/services/image.service';
import { UploadChangeParam, UploadFile } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import { SuggestService } from 'src/app/services/suggest.service';
import { DescriptionValidators } from '../../validators/description.validators';

@Component({
  selector: 'sale-flat',
  templateUrl: './sale-flat.component.html',
  styleUrls: ['./sale-flat.component.less']
})
export class SaleFlatComponent implements OnInit {
  /** форма добавления объявления */
  saleFlatForm: FormGroup;
  /** фото к объявлению */
  images: UploadFile[] = [];
  imageList: UploadFile[] = [];
  /** идентификатор пользователя */
  userId: string;
  /** этаж */
  floor: number;
  /** этажей всего */
  allFloor: number;
  /** кол-во комнат */
  rooms: number;
  /** общая площадь, кв.м */
  flatArea: number;
  /** жилая площадь, кв.м */
  flatLiveArea: number;
  /** площадь кухни, кв.м */
  kitchenArea: number;
  /** балкон */
  selectedBalcony: number = 1;
  listOfBalcony: Array<{ label: string, value: number }> = [];
  /** санузел */
  selectedToilet: number = 1;
  listOfToilet: Array<{ label: string, value: number }> = [];
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
    private advertService: AdvertService,
    public imageService: ImageService,
    public suggestService: SuggestService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.userId = this.authService.currentUser.sub;
    this.initForm();
  }
  /** инициализация формы */
  private initForm(){
    this.setListOfBalcony();
    this.setListOfToilet();
    this.saleFlatForm = this.formBuilder.group({
      userId:[ this.userId ,[Validators.required]],
      isActive: [ true ],
      images: [ this.images, [Validators.required]],
      address: [ null, [Validators.required]],
      floor: [ this.floor, [Validators.required]],
      allFloor: [ this.allFloor, [Validators.required]],
      rooms: [ this.rooms, [Validators.required]],
      flatArea: [ this.flatArea, [Validators.required]],
      flatLiveArea: [ this.flatLiveArea, [Validators.required]],
      kitchenArea: [ this.kitchenArea, [Validators.required]],
      balcony: [ this.selectedBalcony, [Validators.required]],
      toilet: [ this.selectedToilet, [Validators.required]],
      price: [ null, [Validators.required]],
      phone: [ this.phone, [Validators.required, Validators.pattern("[0-9]*")]],
      description: [ null, [DescriptionValidators.notOnlySpace]]
    })
  }
  /** создание объявления */
  submitForm(){
    const saleFlatModel: FlatSaleModel = { ...this.saleFlatForm.value }
    this.advertService.addFlatSale(saleFlatModel);
  }
  /** загрузка картинки */
  onUploadChange(info:  UploadChangeParam ){
    this.imageService.handleChange(info).subscribe(response => {
      this.imageList = [...this.imageService.imageList];
      this.images = response;
      this.setSaleFlatFormControlValue('images',this.images);
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
          this.setSaleFlatFormControlValue('images', this.images);
          observer.next(response);
          observer.complete();
          }
        });
      }
    })
  }
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
  /**
   * установка значения для поля формы
   * @param formControlName имя поля 
   * @param value значение 
   */
  private setSaleFlatFormControlValue(formControlName: string, value: any){
    this.saleFlatForm.controls[formControlName].setValue(value);
  };
}
