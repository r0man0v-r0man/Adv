import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { UserWarning } from '../errors/userWarning';
import { Constants } from '../constants';
import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { UploadFile } from 'ng-zorro-antd/upload';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  /** Max file size in mb */
  maxFileSize = 5;
  deleteImageUrl: string = Constants.deleteFileUrl;
  constructor(
    private authService: AuthService,
    private httpService: HttpClient
  ) { }
  transformFile = (file: UploadFile) => {
    return new Observable((observer: Observer<Blob>) => {
      const width = 600; // For scaling relative to width
      const reader = new FileReader();
      // tslint:disable-next-line: no-any
      reader.readAsDataURL(file as any);
      reader.onload = () => {
        const canvas = document.createElement('canvas');
        const img = document.createElement('img');
        img.src = reader.result as string;
        img.onload = () => {
          const ctx = canvas.getContext('2d')!;
          ctx.drawImage(img, 0, 0);
          ctx.fillStyle = 'red';
          ctx.textBaseline = 'middle';
          ctx.fillText('Ant Design', 20, 20);
          canvas.toBlob(blob => {
            observer.next(blob!);
            observer.complete();
          });
        };
      };
    });
  };
    /** изменение длины/ширины изображения */
   compress(file: File): Observable<any> {
      const width = 600; // For scaling relative to width
      const reader = new FileReader();
      reader.readAsDataURL(file);
      return Observable.create(observer => {
        reader.onload = ev => {
          const img = new Image();
          img.src = (ev.target as any).result;
          (img.onload = () => {
            const elem = document.createElement('canvas'); // Use Angular's Renderer2 method
            const scaleFactor = width / img.naturalHeight;
            elem.width = width;
            elem.height = img.naturalHeight * scaleFactor;
            const ctx = <CanvasRenderingContext2D>elem.getContext('2d');
            var offsetX = 0.5;   // center x
            var offsetY = 0.5;   // center y
            this.drawImageProp(ctx, img, 0, 0, width, img.naturalHeight * scaleFactor, offsetX, offsetY);
            ctx.font = "20px Verdana";
            ctx.fillStyle = "white";
            ctx.globalAlpha = 0.5;
            ctx.fillText('halupa.by', 20 , width - 20);
            ctx.canvas.toBlob(
              blob => {
                observer.next(
                  new File([blob], file.name, {
                    type: 'image/jpeg',
                    lastModified: Date.now(),
                  }),
                );
              },
              'image/jpeg',
              1,
            );
          }),
            (reader.onerror = error => observer.error(error));
        };
      });
    }
  
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
  beforeUpload = (file: File) : boolean => {
    const isSizeLimit = file.size / 1024 / 1024 < this.maxFileSize;
      if (!isSizeLimit) {
        throw new UserWarning(`Максимальный размер изображения ${this.maxFileSize}mb`);
      } else {
        return true
      }
      // else {
      //   return this.compress(file);
      // }
  }
  /** удалить изображение */
  delete(fileName: string){
    return this.httpService.delete<boolean>(this.deleteImageUrl + '/' + fileName, { headers: this.authService.SecureHeaders })
  }
}
