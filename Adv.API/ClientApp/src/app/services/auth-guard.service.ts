import { Injectable } from '@angular/core';
import { Router, RouterStateSnapshot, CanActivate } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(
    private router: Router,
    private authService: AuthService
  ) { }

  canActivate(route, state: RouterStateSnapshot){
    if(this.authService.isLogedIn()) return true;

    this.router.navigate(['/login'], { queryParams : { returnUrl: state.url }});
    return false;
  }
}