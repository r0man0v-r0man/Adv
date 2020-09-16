import { Component, OnInit, ChangeDetectorRef, ViewChild } from '@angular/core';
import { FormGroup} from '@angular/forms';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { AdvertService } from 'src/app/services/advert.service';
import { ImageService } from 'src/app/services/image.service';
import { NzUploadChangeParam, NzUploadFile } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import {SaleFlatFormService} from './services/sale-flat-form.service';
import { CheckoutComponent } from 'src/app/common/payment/checkout/checkout.component';

@Component({
  selector: 'app-sale-flat',
  templateUrl: './sale-flat.component.html',
  styleUrls: ['./sale-flat.component.less'],
  providers: [
    SaleFlatFormService
  ]
})
export class SaleFlatComponent implements OnInit {
  /** фото к объявлению */
  images: NzUploadFile[] = [];
  imageList: NzUploadFile[] = [];

  @ViewChild(CheckoutComponent) checkout: CheckoutComponent;


  get form(): FormGroup {
    return this.saleFlatFormService.form;
  }
  get isValid() {
    return this.saleFlatFormService.isValid;
  }
  get listOfBalcony() {
    return this.saleFlatFormService.listOfBalcony;
  }
  get listOfToilet() {
    return this.saleFlatFormService.listOfToilet;
  }

  constructor(
    private saleFlatFormService: SaleFlatFormService,
    private advertService: AdvertService,
    public imageService: ImageService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
  }

  /** создание объявления */
  submitForm() {
    const saleFlatModel: FlatSaleModel = { ...this.form.value };
    this.advertService.addFlatSale(saleFlatModel); 
  }
  /** загрузка картинки */
  onUploadChange(info: NzUploadChangeParam ){
    this.imageService.handleChange(info).subscribe(response => {
      this.imageList = [...this.imageService.imageList];
      this.images = response;
      this.setSaleFlatFormControlValue('images', this.images);
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
          this.setSaleFlatFormControlValue('images', this.images);
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
  private setSaleFlatFormControlValue(formControlName: string, value: any) {
    this.form.controls[formControlName].setValue(value);
  }
}
