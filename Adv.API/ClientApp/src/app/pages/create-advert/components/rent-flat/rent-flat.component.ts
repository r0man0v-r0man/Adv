import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { AdvertService } from 'src/app/services/advert.service';
import { ImageService } from 'src/app/services/image.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { NzUploadFile, NzUploadChangeParam } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import { DescriptionValidators } from '../../validators/description.validators';
import { Duration } from 'src/app/models/duration';

@Component({
  selector: 'app-rent-flat',
  templateUrl: './rent-flat.component.html',
  styleUrls: ['./rent-flat.component.less']
})
export class RentFlatComponent implements OnInit {
  /** форма добавления объявления */
  flatRentForm: FormGroup;
  /** фото к объявлению */
  images: NzUploadFile[] = [];
  imageList: NzUploadFile[] = [];
  /** идентификатор пользователя */
  userId: string;
  /** этаж */
  floor: number;
  /** этажей всего */
  allFloor: number;
  /** кол-во комнат */
  rooms: number;
  /** балкон */
  selectedBalcony = 1;
  listOfBalcony: Array<{ label: string, value: number }> = [];
  /** мебель */
  furniture = false;
  /** холодильник */
  refrigerator = false;
  /** микроволновая печь */
  microwaveOven = false;
  /** интернет */
  internet = false;
  /** стиральная машина */
  washingMachine = false;
  /** цена */
  price = 300;
  /** тип аренды */
  selectedDuration = 0;
  listOfDuration: Array<{ label: string; value: number}> = [];
  /** телефон */
  phone = '80291234567';
  /** описание */
  description = '';
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');


  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private advertService: AdvertService,
    public imageService: ImageService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.userId = this.authService.currentUser.sub;
    this.initForm();
  }
  initForm() {
    this.setListOfBalcony();
    this.setDurations();
    this.flatRentForm = this.formBuilder.group({
      userId: [ this.userId, [Validators.required]],
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
      phone: [ this.phone, [Validators.required, Validators.pattern('[0-9]*')]],
      description: [ null, [DescriptionValidators.notOnlySpace]],
      city: [ null, [Validators.required]]
    });
  }

  /** создание объявления */
  submitForm() {
    const rentFlatModel: FlatRentModel = { ...this.flatRentForm.value };
    this.advertService.addFlatRent(rentFlatModel);
  }
  /** загрузка картинки */
  onUploadChange(info: NzUploadChangeParam ) {
    this.imageService.handleChange(info).subscribe(response => {
      this.imageList = [...this.imageService.imageList];
      this.images = response;
      this.setRentFlatFormControlValue('images', this.images);
      this.cd.detectChanges();
    });
  }
  /** Delete file */
  onDelete = (file: NzUploadFile): Observable<boolean> => {
    return new Observable(observer => {
      if (file) {
        this.imageService.delete(file.response.deleteHash)
        .subscribe(response => {
          if (response) {
          const index = this.images.findIndex(x => x.uid === file.response.uid);
          if (index > -1) {
            this.images.splice(index, 1);
          }
          this.setRentFlatFormControlValue('images', this.images);
          observer.next(response);
          observer.complete();
          }
        });
      }
    });
  }
  /** установка наличия балкона */
  setListOfBalcony() {
    this.listOfBalcony.push(
      { label: 'Есть', value: 1 },
      { label: 'Нет', value: 0 }
    );
  }
  /** установка списка типов аренды */
  setDurations() {
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
  private setRentFlatFormControlValue(formControlName: string, value: any) {
    this.flatRentForm.controls[formControlName].setValue(value);
  }
}
