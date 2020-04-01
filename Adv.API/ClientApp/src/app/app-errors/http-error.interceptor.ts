import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BadInput } from './bad-input';
import { NotFoundError } from './not-found-error';
import { AppError } from './app-error';
import { Router } from '@angular/router';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor{

    constructor(
        private router: Router
    ){}

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
        this.router.navigate(['/access-denied']);

    
        
      return throwError(new AppError(error));
      }
}