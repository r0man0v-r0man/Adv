import { Component, forwardRef } from '@angular/core';
import { ImageInputService } from 'src/app/services/image-input.service';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { NzUploadChangeParam, NzUploadFile } from 'ng-zorro-antd/upload';
import { Observable } from 'rxjs';
import { response } from 'express';

@Component({
  selector: 'app-image-input',
  templateUrl: './image-input.component.html',
  styleUrls: ['./image-input.component.less'],
  providers: [
    ImageInputService,
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ImageInputComponent),
      multi: true
    }
  ]
})
export class ImageInputComponent implements ControlValueAccessor {
  fullInfoImageList: NzUploadFile[] = [];
  images: NzUploadFile[] = [];
  inputValue = null;
  constructor(
    private imageInputService: ImageInputService
  ) { }

  get actionUrl() {
    return this.imageInputService.uploadUrl;
  }
  get headers() {
    return this.imageInputService.headers();
  }
  get showUploadList() {
    return this.imageInputService.showUploadList;
  }
  onChange: any = () => {};
  onTouched: any = () => {};
  writeValue(input: any): void {
    this.inputValue = input;
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
  onModelChange() {
    this.onChange(this.inputValue);
  }
  /** загрузка картинки */
  onUploadChange(info: NzUploadChangeParam ) {
    this.imageInputService.handleChange(info).subscribe(response => {
      this.fullInfoImageList = [...this.imageInputService.imageList];
      this.images = response;
      this.onChange(this.images);
    });
  }
// /** Delete file */
// onDelete = (file: NzUploadFile): Observable<boolean> => {
//   return new Observable(observer => {
//     if (file) {
//       this.imageInputService.delete(file.response.deleteHash)
//       .subscribe(response => {
//         if (response) {
//         const index = this.images.findIndex(x => x.uid === file.response.uid);
//         if (index > -1) {
//           this.images.splice(index, 1);
//         }
//         //this.setRentFlatFormControlValue('images', this.images);
//         observer.next(response);
//         observer.complete();
//         }
//       });
//     }
//   });
}
