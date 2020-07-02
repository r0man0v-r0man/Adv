import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { AdvertService } from 'src/app/services/advert.service';
import { ImageService } from 'src/app/services/image.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { NzUploadFile, NzUploadChangeParam } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import { Duration } from 'src/app/models/duration';
import {RentFlatFormService} from './services/rent-flat-form.service';

@Component({
  selector: 'app-rent-flat',
  templateUrl: './rent-flat.component.html',
  styleUrls: ['./rent-flat.component.less'],
  providers: [
    RentFlatFormService
  ]
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

  /** телефон */
  phone = '80291234567';
  /** описание */
  description = '';
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');


  get form(): FormGroup {
    return this.rentFlatFormService.form;
  }
  get isValid() {
    return this.rentFlatFormService.isValid;
  }
  constructor(
    private rentFlatFormService: RentFlatFormService,
    private authService: AuthService,
    private advertService: AdvertService,
    public imageService: ImageService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
  }

  /** создание объявления */
  submitForm() {
    const rentFlatModel: FlatRentModel = { ...this.form.value };
    console.log(rentFlatModel);
    this.advertService.addFlatRent(this.form.value);
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
  /**
   * установка значения для поля формы
   * @param formControlName имя поля
   * @param value значение
   */
  private setRentFlatFormControlValue(formControlName: string, value: any) {
    this.form.controls[formControlName].setValue(value);
  }
}
