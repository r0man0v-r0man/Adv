import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { FlatsComponent } from './components/flat/flats/flats.component';
import { FlatDetailComponent } from './components/flat/flat-detail/flat-detail.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';
import { SearchResultComponent } from './components/search-result/search-result/search-result.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    data: {
      title: 'Halupa.by - Сайт по аренде жилья в Несвиже',
      descrption: 'Сайт по аренде жилья в Несвиже. Объявления об аренде квартир и домов, на сутки/часы или на длительное время. У нас можно снять квартиру или дом, наличный и безналичный расчет.'
    }
  },
  {
    path: 'flats',
    component: FlatsComponent,
    data: {
      title: 'Halupa.by - Все квартиры',
      descrption: 'Все квартиры, которые можно снять в Несвиже на часы/сутки или на длительное время'
    }
  },
  {
    path: 'flats/:id',
    component: FlatDetailComponent,
    data: {
      title: 'Halupa.by - Информация о квартире',
      descrption: 'Подробная информация о квартире'
    }
  },
  {
    path: 'search-result',
    component: SearchResultComponent,
    data: {
      title: 'Halupa.by - Результаты поиска',
      descrption: 'Результаты поиска квартиры',
      robots: 'noindex, nofollow'
    }
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {
      title: 'Halupa.by - Войти',
      descrption: 'Войти на Halupa.by'
    }
  },
  {
    path: 'register',
    component: RegisterComponent,
    data: {
      title: 'Halupa.by - Регистрация',
      descrption: 'Зарегистрироваться на Halupa.by'
    }
  },
  {
    path: 'access-denied',
    component: AccessDeniedComponent,
    data: {
      title: 'Halupa.by - Доступ запрещен',
      descrption: 'Извните, но у вас нет доступа'
    }
  },
  {  
    path: '**', 
    component: NotFoundComponent,
    data:{
      robots: 'noindex, nofollow'
    }
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabled'
})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
