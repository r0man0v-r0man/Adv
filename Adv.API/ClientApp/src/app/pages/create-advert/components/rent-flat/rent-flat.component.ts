import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { AdvertService } from 'src/app/services/advert.service';
import { ImageService } from 'src/app/services/image.service';
import { SuggestService } from 'src/app/services/suggest.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { UploadFile, UploadChangeParam } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';

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
  showUploadList = { showPreviewIcon: false, showRemoveIcon: true }
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private advertService: AdvertService,
    public imageService: ImageService,
    public suggestService: SuggestService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {

  }
  initForm(){
    this.flatRentForm = this.formBuilder.group({
      userId:[ this.authService.currentUser.sub,[Validators.required]],
      isActive: [ true ],
      images: [ this.images, [Validators.required]],
      address: [ null, [Validators.required]],
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
    /**
   * установка значения для поля формы
   * @param formControlName имя поля 
   * @param value значение 
   */
  private setRentFlatFormControlValue(formControlName: string, value: any){
    this.flatRentForm.controls[formControlName].setValue(value);
  };
}
