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
import { SearchResultComponent } from './components/search-result/search-result/search-result.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    data: {
      title: 'Halupa.by'
    }
  },
  {
    path: 'flats/:id',
    component: FlatDetailComponent,
    data: {
      title: 'Квартиры'
    }
  },
  {
    path: 'flats',
    component: FlatsComponent,
    data: {
      title: 'Квартиры'
    }
  },
  {
    path: 'search-result',
    component: SearchResultComponent,
    data: {
      title: 'Результаты поиска'
    }
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {
      title: 'Войти'
    }
  },
  {
    path: 'register',
    component: RegisterComponent,
    data: {
      title: 'Регистрация'
    }
  },
  {
    path: 'access-denied',
    component: AccessDeniedComponent,
    data: {
      title: 'Доступ запрещен'
    }
  },
  {  
    path: '**', 
    component: NotFoundComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
