import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ImageService } from 'src/app/services/image.service';
import { AdvertService } from 'src/app/services/advert.service';
import { NzUploadFile, NzUploadChangeParam } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import { HouseRentModel } from 'src/app/models/house-rent.model';
import {RentHouseFormService} from './services/rent-house-form.service';

@Component({
  selector: 'app-rent-house',
  templateUrl: './rent-house.component.html',
  styleUrls: ['./rent-house.component.less'],
  providers: [
    RentHouseFormService
  ]
})
export class RentHouseComponent implements OnInit {
  /** фото к объявлению */
  images: NzUploadFile[] = [];
  imageList: NzUploadFile[] = [];


  get form(): FormGroup {
    return this.rentHouseFormService.form;
  }
  get isValid() {
    return this.rentHouseFormService.isValid;
  }
  get listOfDuration() {
    return this.rentHouseFormService.listOfDuration;
  }

  constructor(
    private rentHouseFormService: RentHouseFormService,
    public imageService: ImageService,
    private advertService: AdvertService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
  }

  submitForm() {
    const rentHouseModel: HouseRentModel = { ...this.form.value };
    this.advertService.addHouseRent(rentHouseModel);
  }
  /** загрузка картинки */
  onUploadChange(info: NzUploadChangeParam ) {
    this.imageService.handleChange(info).subscribe(response => {
      this.imageList = [...this.imageService.imageList];
      this.images = response;
      this.setHouseRentFormControlValue('images', this.images);
      this.cd.detectChanges();
    });
  }
  /** Delete file */
  onDelete = (file: NzUploadFile) : Observable<boolean> => {
    return new Observable(observer => {
      if (file) {
        this.imageService.delete(file.response.deleteHash)
        .subscribe(response => {
          if (response) {

          const index = this.images.findIndex(x => x.uid === file.response.uid);

          if (index > -1) {
            this.images.splice(index, 1);
          }
          this.setHouseRentFormControlValue('images', this.images);
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
  private setHouseRentFormControlValue(formControlName: string, value: any) {
    this.form.controls[formControlName].setValue(value);
  }
}
