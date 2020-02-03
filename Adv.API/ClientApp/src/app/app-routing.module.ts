import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { FlatsComponent } from './components/flat/flats/flats.component';
import { FlatDetailComponent } from './components/flat/flat-detail/flat-detail.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { AppComponent } from './app.component';
import { AuthGuardService } from './services/auth-guard.service';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'flats/:id',
    component: FlatDetailComponent
  },
  {
    path: 'flats',
    component: FlatsComponent,
  },

  {
    path: 'login',
    component: AppComponent,
    children:[
      {
        path: '',
        component: LoginComponent
      }
    ]
  },
  {
    path: 'register',
    component: AppComponent,
    children:[
      {
        path: '',
        component: RegisterComponent
      }
    ]
  },
  {
    path: 'access-denied',
    component: AppComponent,
    children:[
      {
        path:'',
        component: AccessDeniedComponent
      }
    ]
  },
  {  
    path: '**', 
    component: NotFoundComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
