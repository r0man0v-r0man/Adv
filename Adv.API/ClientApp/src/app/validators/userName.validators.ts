import { FormControl, ValidationErrors } from '@angular/forms';
import { Observable, Observer } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { Injectable } from '@angular/core';
@Injectable()
export class UserNameValidators {
   static duplicated(authService: AuthService){
    return (control: FormControl) =>
        new Observable((observer: Observer<ValidationErrors | null>) => {
            setTimeout(() => {
                authService.IsUserNameExist(control.value)
                .subscribe(response => {
                    if(response){
                        // you have to return `{error: true}` to mark it as an error event
                        observer.next({ error: true, duplicated: true });
                    } else {
                        observer.next(null);
                    }
                    observer.complete();
                })
            }, 1000);
            
   })
}
}