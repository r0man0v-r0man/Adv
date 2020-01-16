import { ErrorHandler, OnInit, Injectable, Injector } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { AppError } from './app-error';
import { BadInput } from './bad-input';
import { NotFoundError } from './not-found-error';
import { UserWarning } from './userWarning';
import { AccessDenied } from './access-denied';
import { Router } from '@angular/router';


@Injectable({
    providedIn: 'root'
  })
export class AppErrorHandler implements ErrorHandler, OnInit{
    constructor(
        private msg: NzMessageService
        ){}
    ngOnInit() {
    }
    handleError(error: AppError) {
        if(
            (error instanceof BadInput) || 
            (error instanceof NotFoundError)
        ){
            this.msg.error(error.error);
        }
        if(error instanceof UserWarning){
            this.msg.warning(error.error);
        }
        if(error instanceof AccessDenied){
            console.log('Access denied!');
        }
        
        console.log(error);
    }

}