import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DescriptionValidators } from 'src/app/validators/description.validators';
import { Constants } from 'src/app/constants';
import { UploadFile, NzMessageService } from 'ng-zorro-antd';
import { UserWarning } from 'src/app/app-errors/userWarning';
import { Observable } from 'rxjs';
import { FileService } from 'src/app/services/file.service';
import ymaps from 'ymaps';
import { AuthService } from 'src/app/services/auth.service';
import { Cities } from 'src/app/models/cities';

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
  /** Selected City, default district is: 0 */
  selectedCity: number = 0;
  /** Array of cities */
  listOfCities: Array<{ label: string; value: number}> = [];
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
  /** city */
  city: string;
  /** count of rooms */
  rooms: number;
  /** duration long or short */
  duration:number;
  /** exist or not */
  furniture: boolean;
  /** exist or not */
  refrigerator: boolean;
  /** exist or not */
  microwaveOven: boolean;
  /** exist or not */
  internet:boolean;
  /** exist or not */
  washingMachine:boolean;
  /** flat floor */
  floor: number;
  /** Count all floor of house */
  allFloor?: number; 

  form: FormGroup;
  fileList : UploadFile[] = [];
  /**file from success status from server */
  files: UploadFile[] = [];
  showUploadList = {
    showPreviewIcon: false,
    showRemoveIcon: true
  }

  constructor(
    private formBuilder: FormBuilder, 
    private messageService: NzMessageService,
    private fileService: FileService,
    private authService: AuthService
    ) { }

  ngOnInit() {
    this.initForm();
    this.setCities();
  }
  headers = () => {
    return this.authService.Token;
  };
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
      files: [this.fileList, [Validators.required]],
      city: [this.selectedCity, [Validators.required]],
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
  setCities(){
    this.listOfCities.push(
      { label: 'Несвиж', value: Cities.nesvizh }
      );
  }
  onChange(info: { file : UploadFile} ){
     if(info.file.status === 'done' && info.file.response) 

     this.files.push(info.file.response);

     this.setFormControlValue('files', this.files);
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
        this.fileService.deleteFile(this.deleteFileUrl, file.response.name)
        .subscribe(response =>{
          if(response) {
            
          let index = this.files.findIndex(x=>x.uid === file.response.uid);
          
          if(index > -1) {
            this.files.splice(index, 1);
          }
          this.setFormControlValue('files', this.files);

          observer.next(response);
          observer.complete();
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