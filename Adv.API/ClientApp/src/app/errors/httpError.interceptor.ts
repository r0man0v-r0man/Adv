import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BadInput } from './badInput';
import { AppError } from './appError';
import { NotFoundError } from './notFoundError';
import { AccessDeniedError } from './accessDeniedError';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor{

    constructor(){}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request)
            .pipe(
                catchError((error)=>this.handleError(error))
            )
    }
    private handleError(error: HttpErrorResponse){
        if(error.status === 400)
        return throwError(new BadInput(error.error));
      
        if(error.status === 404)
        return throwError(new NotFoundError(error.error));
    
        if(error.status === 401)
        return throwError(new AccessDeniedError(error.error));

    
        
      return throwError(new AppError(error));
      }
}