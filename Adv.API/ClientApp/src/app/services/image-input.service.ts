import { Injectable } from '@angular/core';
import { Constants } from '../constants';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { UploadFile, UploadChangeParam, NzUploadChangeParam, NzUploadFile } from 'ng-zorro-antd/upload';
import { Observable, Observer } from 'rxjs';
import { NzMessageService } from 'ng-zorro-antd/message';

@Injectable()
export class ImageInputService {
  /** uploadUrl используется в шаблоне */
  uploadUrl = Constants.uploadFileUrl;
  /** header c JWT токеном для загрузки фото */
  headers = () => { return this.authService.Token; };
  /** Max file size in mb */
  maxFileSize = 5;
  deleteImageUrl: string = Constants.deleteFileUrl;
  /** для nz-upload */
  imageList: UploadFile[] = [];
  /** для формы */
  images: UploadFile[] = [];
  /** настройки списка загруженных картинок */
  showUploadList = { showPreviewIcon: false, showRemoveIcon: true }
  constructor(
    private authService: AuthService,
    private httpService: HttpClient,
    private msg: NzMessageService
  ) { }
  /** изменение разрешения изображения */
  transformFile = (file: UploadFile) => {
    return new Observable((observer: Observer<Blob>) => {
      const width = 600; // разрешение картинки
      const reader = new FileReader();
      reader.readAsDataURL(file as any);
      reader.onload = () => {
        const canvas = document.createElement('canvas');
        const img = document.createElement('img');
        img.src = reader.result as string;
       
        img.onload = () => {
          const scale = width / img.naturalHeight;
          canvas.width = width;
          canvas.height = img.naturalHeight * scale;
          const ctx = canvas.getContext('2d')!;
          var offsetX = 0.5;   // center x
          var offsetY = 0.5;   // center y
          this.drawImageProp(ctx, img, 0, 0, width, img.naturalHeight * scale, offsetX, offsetY);
          ctx.font = "20px Verdana";
            ctx.fillStyle = "white";
            ctx.globalAlpha = 0.5;
            ctx.fillText('halupa.by', 20 , width - 20);
          canvas.toBlob(blob => {
            observer.next(blob!);
            observer.complete();
          });
        };
      };
    });
  };
  
  /**
   * By Ken Fyrstenberg Nilsen
   *
   * drawImageProp(context, image [, x, y, width, height [,offsetX, offsetY]])
   *
   * If image and context are only arguments rectangle will equal canvas
  */
  private drawImageProp(ctx, img, x, y, w, h, offsetX, offsetY) {
  
    if (arguments.length === 2) {
        x = y = 0;
        w = ctx.canvas.width;
        h = ctx.canvas.height;
    }
  
    // default offset is center
    offsetX = typeof offsetX === "number" ? offsetX : 0.5;
    offsetY = typeof offsetY === "number" ? offsetY : 0.5;
  
    // keep bounds [0.0, 1.0]
    if (offsetX < 0) offsetX = 0;
    if (offsetY < 0) offsetY = 0;
    if (offsetX > 1) offsetX = 1;
    if (offsetY > 1) offsetY = 1;
  
    var iw = img.width,
        ih = img.height,
        r = Math.min(w / iw, h / ih),
        nw = iw * r,   // new prop. width
        nh = ih * r,   // new prop. height
        cx, cy, cw, ch, ar = 1;
  
    // decide which gap to fill    
    if (nw < w) ar = w / nw;                             
    if (Math.abs(ar - 1) < 1e-14 && nh < h) ar = h / nh;  // updated
    nw *= ar;
    nh *= ar;
  
    // calc source rectangle
    cw = iw / (nw / w);
    ch = ih / (nh / h);
  
    cx = (iw - cw) * offsetX;
    cy = (ih - ch) * offsetY;
  
    // make sure source rectangle is valid
    if (cx < 0) cx = 0;
    if (cy < 0) cy = 0;
    if (cw > iw) cw = iw;
    if (ch > ih) ch = ih;
  
    // fill image in dest. rectangle
    ctx.drawImage(img, cx, cy, cw, ch,  x, y, w, h);
  }
  beforeUpload = (file: File) : Observable<boolean> => {
    return new Observable((observer: Observer<boolean>)=>{
      const isSizeLimit = file.size / 1024 / 1024 < this.maxFileSize;
      if (!isSizeLimit) {
        observer.next(false);
        observer.complete();
        this.msg.warning(`Максимальный размер изображения ${this.maxFileSize}mb`);
      } else {
        observer.next(true);
        observer.complete();
      }
    })
  }
  /** загрузка картинки */
  handleChange(info: NzUploadChangeParam): Observable<NzUploadFile[]> {
    return new Observable(observer => {
      let fileList = [...info.fileList];
      // 2. Read from response and show file link
      fileList = fileList.map(file => {
        if (file.response) {
          // Component will show file.url as link
          file.url = file.response.url;
        }
        return file;
      });
      this.imageList = fileList;
      /** только response сохранять в инфо о картинке к объявлению */
      let images = fileList.map(file => {
        if(file.response){
          file = file.response;
        }
        return file
      });
      observer.next(images);
      observer.complete();
    })
  }
  /** удалить изображение */
  delete(deleteHash: string){
    return this.httpService.delete<boolean>(this.deleteImageUrl + '/' + deleteHash, { headers: this.authService.SecureHeaders })
  }
}
