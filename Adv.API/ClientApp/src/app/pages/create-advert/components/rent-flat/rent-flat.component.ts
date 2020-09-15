import { Component, ChangeDetectorRef } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AdvertService } from 'src/app/services/advert.service';
import { ImageService } from 'src/app/services/image.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { NzUploadFile, NzUploadChangeParam } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import {RentFlatFormService} from './services/rent-flat-form.service';

@Component({
  selector: 'app-rent-flat',
  templateUrl: './rent-flat.component.html',
  styleUrls: ['./rent-flat.component.less'],
  providers: [
    RentFlatFormService
  ]
})
export class RentFlatComponent {
  /** фото к объявлению */
  images: NzUploadFile[] = [];
  imageList: NzUploadFile[] = [];

  get form(): FormGroup {
    return this.rentFlatFormService.form;
  }
  get isValid() {
    return this.rentFlatFormService.isValid;
  }
  get listOfBalcony() {
    return this.rentFlatFormService.listOfBalcony;
  }
  get listOfDuration() {
    return this.rentFlatFormService.listOfDuration;
  }
  
  constructor(
    private rentFlatFormService: RentFlatFormService,
    private advertService: AdvertService,
    public imageService: ImageService,
    private cd: ChangeDetectorRef
  ) { }

  /** создание объявления */
  submitForm() {
    const rentFlatModel: FlatRentModel = { ...this.form.value };
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
  /**
   * установка значения для поля формы
   * @param formControlName имя поля
   * @param value значение
   */
  private setRentFlatFormControlValue(formControlName: string, value: any) {
    this.form.controls[formControlName].setValue(value);
  }
}
