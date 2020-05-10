import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { ImageService } from 'src/app/services/image.service';
import { SuggestService } from 'src/app/services/suggest.service';
import { AdvertService } from 'src/app/services/advert.service';
import { UploadFile, UploadChangeParam } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import { HouseRentModel } from 'src/app/models/house-rent.model';

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

  address: string = '';
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    public imageService: ImageService,
    private cd: ChangeDetectorRef, // для загрузки картинок
    public suggestService: SuggestService,
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.initRentHouseForm();
  }
  private initRentHouseForm(){
    this.rentHouseForm = this.formBuilder.group({
      userId:[ this.authService.currentUser.sub,[Validators.required]],
      isActive: [ true ],
      images: [ this.images, [Validators.required]],
      address: [ this.address, [Validators.required]],
    })
  }
  onFocus(event){
    console.log('1');
    
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
}
