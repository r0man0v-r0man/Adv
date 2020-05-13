import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { AdvertService } from 'src/app/services/advert.service';
import { ImageService } from 'src/app/services/image.service';
import { UploadChangeParam, UploadFile } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import { UserWarning } from 'src/app/errors/userWarning';

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
  showUploadList = { showPreviewIcon: false, showRemoveIcon: true }
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private advertService: AdvertService,
    public imageService: ImageService
  ) { }

  ngOnInit(): void {
    this.initForm();
  }
  /** инициализация формы */
  private initForm(){
    this.saleFlatForm = this.formBuilder.group({
      userId:[ this.authService.currentUser.sub,[Validators.required]],
      isActive: [ true ],
      images: [ this.images, [Validators.required]],
      
    })
  }
  /** создание объявления */
  submitForm(){
    const saleFlatModel: FlatSaleModel = { ...this.saleFlatForm.value }
    this.advertService.addFlatSale(saleFlatModel);
    throw new UserWarning('asdfasdfasdfasdf');
  }
  /** загрузка картинки */
  onUploadChange(info:  UploadChangeParam ){
    this.imageService.handleChange(info).subscribe(response => {
      this.images = response;
      this.setSaleFlatFormControlValue('images',this.images);
      
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

  /**
   * установка значения для поля формы
   * @param formControlName имя поля 
   * @param value значение 
   */
  private setSaleFlatFormControlValue(formControlName: string, value: any){
    this.saleFlatForm.controls[formControlName].setValue(value);
  };
}
