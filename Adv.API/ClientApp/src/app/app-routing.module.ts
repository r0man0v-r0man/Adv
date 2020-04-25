import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from './services/auth-guard.service';

const routes: Routes = 
[
  { 
    path: '', 
    pathMatch: 'full', 
    redirectTo: '/home' 
  },
  { 
    path: 'home', 
    loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule) 
  },
  { 
    path: 'login', 
    loadChildren: () => import('./pages/login/login.module').then(m=>m.LoginModule) 
  },
  { 
    path: 'register', 
    loadChildren: () => import('./pages/register/register.module').then(m=>m.RegisterModule) 
  },
  { 
    path: 'profile', 
    loadChildren: () => import('./pages/profile/profile.module').then(m=> m.ProfileModule),
    canActivate: [AuthGuardService] 
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabled'
})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
