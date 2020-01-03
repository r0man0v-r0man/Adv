import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DescriptionValidators } from 'src/app/validators/description.validators';
import { Constants } from 'src/app/constants';
import { UploadFile, NzMessageService } from 'ng-zorro-antd';
import { UserWarning } from 'src/app/app-errors/userWarning';
import { Observable } from 'rxjs';
import { FileService } from 'src/app/services/file.service';
import { District } from 'src/app/models/distriscts';
import ymaps from 'ymaps';

@Component({
  selector: 'app-add-advert',
  templateUrl: './add-advert.component.html',
  styleUrls: ['./add-advert.component.less']
})
export class AddAdvertComponent implements OnInit {
  deleteFileUrl: string = Constants.deleteFileUrl;
  uploadUrl = Constants.uploadFileUrl;

  /** Minimum dimension/resolution for image */
  minDimension = 1000;
  /** Max file size in mb */
  maxFileSize = 3;
  /** Selected District, default district is: 1 */
  selectedDistrict: number = 1;
  /** Array of districts */
  listOfDistricts: Array<{ label: string; value: number}> = [];
  /** Flat's price, default is: 200 */
  price: number = 200;
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  /** Street, part of address */
  street: string = '';
  /** Number of House, part of address */
  numberOfHouse: number;
  /** Number of House Corpus, part of address */
  numberOfHouseCourpus: number;
  /** Number Of SubHouse, part of address */
  numberOfSubHouse: number;
  /** Number of flat, part of address */
  numberOfFlat: number;


  form: FormGroup;
  fileList : UploadFile[] = [];
  file: UploadFile;
  showUploadList = {
    showPreviewIcon: false,
    showRemoveIcon: true
  }

  constructor(
    private formBuilder: FormBuilder, 
    private messageService: NzMessageService,
    private fileService: FileService) { }

  ngOnInit() {
    this.initForm();
    this.setDistricts();
  }
  /** setup yandex map */
  yandexMapInitialize(){
    ymaps
  .load()
  .then(maps => {
    const map = new maps.Map('yandex-map-container', {
      center: [-8.369326, 115.166023],
      zoom: 7
    });
  })
  .catch(error => console.log('Failed to load Yandex Maps', error));
  }
  /**
   * Initialize form fields
   */
  initForm(){
    this.form = this.formBuilder.group({
      price: [null, [Validators.required]],
      description: [null, [DescriptionValidators.notOnlySpace]],
      file: [this.file, [Validators.required]],
      district: [this.selectedDistrict, [Validators.required]],
      street: [this.street, [Validators.required]],
      numberOfHouse: [null, [Validators.required]],
      numberOfHouseCourpus: [this.numberOfHouseCourpus],
      numberOfSubHouse: [ this.numberOfSubHouse],
      numberOfFlat: [this.numberOfFlat, [Validators.required]]
    });
  }
  /**
   * Set list of districts for select menu
   */
  setDistricts(){
    this.listOfDistricts.push(
      { label: 'Заводской район', value: District.factory },
      { label: 'Ленинский район', value: District.leninsky },
      { label: 'Московский район', value: District.moscow },
      { label: 'Октябрьский район', value: District.october },
      { label: 'Партизанский район', value: District.partisan },
      { label: 'Первомайский район', value: District.firstMay },
      { label: 'Советский район', value: District.sovet },
      { label: 'Центральный район', value: District.central },
      { label: 'Фрунзенский район', value: District.frunzensky}
      );
  }
  onChange(info: { file: UploadFile }){
    if(info.file.status === 'done' && info.file.response) 
    this.setFormControlValue('file', info.file.response);
  }
  /**
   * Check resolution of image
   * @param file checked file
   * @param resolution minimum dimension
   */
  checkImageResolution(file: File, resolution: number) : Observable<boolean>{
    return new Observable(observer=>{
      let width: number, height: number;
      const img = new Image();
      img.src = window.URL.createObjectURL(file);
      img.onload = () => {
        width = img.naturalWidth;
        height = img.naturalHeight;    
        const isMinDimension = (width >= resolution && height >= resolution)
        if(!isMinDimension) throw new UserWarning('Разрешение изображения меньше 1000px');
        
          observer.next(isMinDimension);
          observer.complete();
          window.URL.revokeObjectURL(img.src);
          return;
      }
    })
  }
  /**
   * Delete file
   */
  onDelete = (file: UploadFile) : Observable<boolean> => {
    return new Observable(observer =>{
      console.info(file);
      if(file){
        this.fileService.deleteFile(this.deleteFileUrl, file.response.name).subscribe(response =>{
          if(response) {
          observer.next(response);
          observer.complete();
          this.setFormControlValue('file', null);
          }
        });
      }
    })
  }
  /**
   * Set value to formControl
   * @param formControlName name of form control 
   * @param value value 
   */
  setFormControlValue(formControlName: string, value: any){
    this.form.controls[formControlName].setValue(value);
  };
  /**
   * Check file size and file resolution
   */
  beforeUpload = (file: File) : Observable<boolean> => {
    return new Observable(observer => {
      const isSizeLimit = file.size / 1024 / 1024 < this.maxFileSize;
      if (!isSizeLimit) {
        this.messageService.warning(`Максимальный размер изображения ${this.maxFileSize}mb`);
        observer.complete();
        return;
      }

      this.checkImageResolution(file, this.minDimension).subscribe(
        isResolutionLimit => {
          observer.next(isSizeLimit && isResolutionLimit);
          observer.complete();
        }
      );
    });
  }

}