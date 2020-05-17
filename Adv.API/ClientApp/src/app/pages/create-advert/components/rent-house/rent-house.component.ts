import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { ImageService } from 'src/app/services/image.service';
import { SuggestService } from 'src/app/services/suggest.service';
import { AdvertService } from 'src/app/services/advert.service';
import { UploadFile, UploadChangeParam } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import { HouseRentModel } from 'src/app/models/house-rent.model';
import { DescriptionValidators } from '../../validators/description.validators';
import { Duration } from 'src/app/models/duration';

@Component({
  selector: 'rent-house',
  templateUrl: './rent-house.component.html',
  styleUrls: ['./rent-house.component.less']
})
export class RentHouseComponent implements OnInit {
  /** форма создания объявления */
  rentHouseForm: FormGroup;
  /** фото к объявлению */
  images: UploadFile[] = [];
  showUploadList = { showPreviewIcon: false, showRemoveIcon: true }
  /** адрес */
  address: string = '';
  /** кол-во комнат */
  rooms: number;
  /** мебель */
  furniture: boolean = false;
  /** холодильник */
  refrigerator: boolean = false;
  /** микроволновая печь */
  microwaveOven: boolean = false;
  /** интернет */
  internet: boolean = false;
  /** стиральная машина */
  washingMachine: boolean = false;
  /** баня/сауна */
  bathhouse: boolean = false;
  /** гараж */
  garage: boolean = false;
  /** цена */
  price: number = 30000;
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  /** тип аренды */
  selectedDuration: number = 0;
  listOfDuration: Array<{ label: string; value: number}> = [];
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
    this.initRentHouseForm();
  }
  private initRentHouseForm(){
    this.setDurations();
    this.rentHouseForm = this.formBuilder.group({
      userId:[ this.authService.currentUser.sub,[Validators.required]],
      isActive: [ true ],
      images: [ this.images, [Validators.required]],
      address: [ this.address, [Validators.required]],
      rooms: [ this.rooms ],
      furniture: [this.furniture],
      refrigerator: [ this.refrigerator],
      microwaveOven: [ this.microwaveOven],
      internet: [ this.internet],
      washingMachine: [ this.washingMachine],
      bathhouse: [ this.bathhouse],
      garage: [ this.garage],
      price: [ null, [Validators.required]],
      duration: [ this.selectedDuration, [Validators.required]],
      phone: [ this.phone, [Validators.required, Validators.pattern("[0-9]*")]],
      description: [ null, [DescriptionValidators.notOnlySpace]]
    })
  }
  submitForm(){
    const rentHouseModel: HouseRentModel = { ...this.rentHouseForm.value }
    this.advertService.addHouseRent(rentHouseModel);
  }
  /** загрузка картинки */
  onUploadChange(info:  UploadChangeParam ){
    this.imageService.handleChange(info).subscribe(response => {
      this.images = response;
      this.setHouseRentFormControlValue('images',this.images);
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
          this.setHouseRentFormControlValue('images', this.images);
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
  private setHouseRentFormControlValue(formControlName: string, value: any){
    this.rentHouseForm.controls[formControlName].setValue(value);
  };
  /** установка списка типов аренды */
  setDurations(){
    this.listOfDuration.push(
      { label: 'Длительная', value: Duration.long },
      { label: 'Часы/сутки', value: Duration.short }
      );
  }
}
