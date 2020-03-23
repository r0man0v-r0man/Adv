import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { AppError } from './app-error';
import { BadInput } from './bad-input';
import { NotFoundError } from './not-found-error';
import { UserWarning } from './userWarning';
import { AccessDenied } from './access-denied';


@Injectable({
    providedIn: 'root'
  })
export class AppErrorHandler implements ErrorHandler {
    constructor(
        private injector: Injector
        ){}
    handleError(error: AppError) {
        const msg = this.injector.get(NzMessageService);
        if(
            (error instanceof BadInput) || 
            (error instanceof NotFoundError)
        ){
            msg.error(error.error);
        }
        if(error instanceof UserWarning){
            msg.warning(error.error);
        }
        if(error instanceof AccessDenied){
            console.log('Access denied!');
        }
        
        console.log(error);
    }

}