import { Injectable, ErrorHandler, Injector } from '@angular/core';
import { AppError } from './appError';
import { NzMessageService } from 'ng-zorro-antd/message';
import { UserWarning } from './userWarning';
import { BadInput } from './badInput';
import { NotFoundError } from './notFoundError';
import { Router } from '@angular/router';
import { AccessDeniedError } from './accessDeniedError';

@Injectable({
    providedIn: 'root'
  })
export class AppErrorHandler implements ErrorHandler {
    constructor(
        private injector: Injector,
        private router: Router
        ){
            
        }
    handleError(error: AppError) {
        const msg = this.injector.get(NzMessageService);
        if(error instanceof BadInput){
            msg.error(error.error);
        }
        if(error instanceof UserWarning){
            msg.warning(error.error);
        }
        if(error instanceof NotFoundError){
            this.router.navigate(['/not-found']);
            console.log(error.error);
        }
        if(error instanceof AccessDeniedError){
            this.router.navigate(['/access-denied']);
            console.log(error.error);
        }
        
        console.log(error);
    }

}