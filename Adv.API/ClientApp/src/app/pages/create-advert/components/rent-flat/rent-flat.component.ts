import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { AdvertService } from 'src/app/services/advert.service';
import { ImageService } from 'src/app/services/image.service';
import { SuggestService } from 'src/app/services/suggest.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { UploadFile, UploadChangeParam } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import { DescriptionValidators } from '../../validators/description.validators';
import { Duration } from 'src/app/models/duration';
import { City } from 'src/app/models/city.model';

@Component({
  selector: 'rent-flat',
  templateUrl: './rent-flat.component.html',
  styleUrls: ['./rent-flat.component.less']
})
export class RentFlatComponent implements OnInit {
  /** форма добавления объявления */
  flatRentForm: FormGroup;
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
  /** балкон */
  selectedBalcony: number = 1;
  listOfBalcony: Array<{ label: string, value: number }> = [];
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
  /** цена */
  price: number = 300;
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  /** тип аренды */
  selectedDuration: number = 0;
  listOfDuration: Array<{ label: string; value: number}> = [];
  /** телефон */
  phone: string = '80291234567';
  /** описание */
  description: string = '';
/** Selected City, default district is: 0 */
selectedCity: City;
/** Array of cities */
listOfCities: City[] = [];
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private advertService: AdvertService,
    public imageService: ImageService,
    public suggestService: SuggestService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.userId = this.authService.currentUser.sub
    this.initForm();
  }
  initForm(){
    this.setListOfBalcony();
    this.setDurations();
    this.setCitiesName();
    this.flatRentForm = this.formBuilder.group({
      userId:[ this.userId ,[Validators.required]],
      isActive: [ true ],
      images: [ this.images, [Validators.required]],
      address: [ null, [Validators.required]],
      floor: [ this.floor, [Validators.required]],
      allFloor: [ this.allFloor, [Validators.required]],
      rooms: [ this.rooms, [Validators.required]],
      balcony: [ this.selectedBalcony, [Validators.required]],
      furniture: [this.furniture],
      refrigerator: [ this.refrigerator],
      microwaveOven: [ this.microwaveOven],
      internet: [ this.internet],
      washingMachine: [ this.washingMachine],
      price: [ null, [Validators.required]],
      duration: [ this.selectedDuration, [Validators.required]],
      phone: [ this.phone, [Validators.required, Validators.pattern("[0-9]*")]],
      description: [ null, [DescriptionValidators.notOnlySpace]],
      city: [this.selectedCity, [Validators.required]]
    })
  }
  setCitiesName(){
    this.suggestService.getCities().subscribe(response => {
      if(response){        
        let listOfOption: City[] = [];
        listOfOption = [...response]
        this.listOfCities = listOfOption;
      }
    })
  }
  /** создание объявления */
  submitForm(){
    const rentFlatModel: FlatRentModel = { ...this.flatRentForm.value }
    this.advertService.addFlatRent(rentFlatModel);
  }
  /** загрузка картинки */
  onUploadChange(info:  UploadChangeParam ){
    this.imageService.handleChange(info).subscribe(response => {
      this.imageList = [...this.imageService.imageList];
      this.images = response;
      this.setRentFlatFormControlValue('images',this.images);
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
          this.setRentFlatFormControlValue('images', this.images);
          observer.next(response);
          observer.complete();
          }
        });
      }
    })
  }
  /** установка наличия балкона */
  setListOfBalcony(){
    this.listOfBalcony.push(
      { label: 'Есть', value: 1 },
      { label: 'Нет', value: 0 }
    )
  }
  /** установка списка типов аренды */
  setDurations(){
    this.listOfDuration.push(
      { label: 'Длительная', value: Duration.long },
      { label: 'Часы/сутки', value: Duration.short }
      );
  }
    /**
   * установка значения для поля формы
   * @param formControlName имя поля 
   * @param value значение 
   */
  private setRentFlatFormControlValue(formControlName: string, value: any){
    this.flatRentForm.controls[formControlName].setValue(value);
  };
}
