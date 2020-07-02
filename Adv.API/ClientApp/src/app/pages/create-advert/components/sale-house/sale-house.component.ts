import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { ImageService } from 'src/app/services/image.service';
import { Observable } from 'rxjs';
import { NzUploadFile, NzUploadChangeParam } from 'ng-zorro-antd/upload';
import { HouseSaleModel } from 'src/app/models/house-sale.model';
import { AdvertService } from 'src/app/services/advert.service';
import {SaleHouseFormService} from './services/sale-house-form.service';

@Component({
  selector: 'app-sale-house',
  templateUrl: './sale-house.component.html',
  styleUrls: ['./sale-house.component.less'],
  providers: [
    SaleHouseFormService
  ]
})
export class SaleHouseComponent implements OnInit{
  /** фото к объявлению */
  imageList: NzUploadFile[] = [];
  images: NzUploadFile[] = [];
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  get form(): FormGroup {
    return this.saleHouseFormService.form;
  }
  get isValid() {
    return this.saleHouseFormService.isValid;
  }
  constructor(
    private saleHouseFormService: SaleHouseFormService,
    private formBuilder: FormBuilder,
    private authService: AuthService,
    public imageService: ImageService,
    private advertService: AdvertService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
  }

  submitForm() {
    const advert: HouseSaleModel = { ...this.form.value };
    this.advertService.addHouseSale(advert);
  }
  /** загрузка картинки */
  onUploadChange(info: NzUploadChangeParam ) {
    this.imageService.handleChange(info).subscribe(response => {
      this.imageList = [...this.imageService.imageList];
      this.images = response;
      this.setHouseSaleFormControlValue('images', this.images);
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
          this.setHouseSaleFormControlValue('images', this.images);
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
  private setHouseSaleFormControlValue(formControlName: string, value: any) {
    this.form.controls[formControlName].setValue(value);
  }
}
