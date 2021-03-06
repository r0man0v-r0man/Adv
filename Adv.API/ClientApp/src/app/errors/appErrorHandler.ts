import { Injectable, ErrorHandler, Injector } from '@angular/core';
import { AppError } from './appError';
import { NzMessageService } from 'ng-zorro-antd/message';
import { UserWarning } from './userWarning';
import { BadInput } from './badInput';
import { AccessDeniedError } from './accessDeniedError';
import { NotFoundError } from './notFoundError';

@Injectable({
    providedIn: 'root'
  })
export class AppErrorHandler implements ErrorHandler {
    constructor(
        private injector: Injector
        ){ }
    handleError(error: AppError) {
        const msg = this.injector.get(NzMessageService);
        if(error instanceof BadInput){
            msg.error(error.error);
        }
        if(error instanceof UserWarning){
            msg.warning(error.error);
        }
        if(error instanceof NotFoundError){
            console.log(error.error)
        }
        if(error instanceof AccessDeniedError){
            console.log(error.error)
        }
        
        console.log(error);
    }

}