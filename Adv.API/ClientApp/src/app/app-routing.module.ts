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
    loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule),
    data: {
      hideComponents: false,
      title: 'Halupa.by - Сайт по аренде и продаже недвижимости №1 в Беларуси',
      description: 'Сайт по аренде и продаже недвижимости. Halupa.by - ваш помошник в поиске квартиры или дома для покупки или аренды. Объявления от собственника за наличный и безналичный расчет.'
    }
  },
  { 
    path: 'login', 
    loadChildren: () => import('./pages/login/login.module').then(m=>m.LoginModule),
    data: {
      hideComponents: true,
      title: 'Halupa.by - Войти',
      description: 'Войти на сайт',
      robots: 'noindex, nofollow'
    }
  },
  { 
    path: 'register', 
    loadChildren: () => import('./pages/register/register.module').then(m=>m.RegisterModule),
    data: {
      hideComponents: true,
      title: 'Halupa.by - Регистрация',
      description: 'Регистрация нового пользователя',
      robots: 'noindex, nofollow'
    }
  },
  { 
    path: 'profile', 
    loadChildren: () => import('./pages/profile/profile.module').then(m=> m.ProfileModule),
    data: {
      hideComponents: false,
      title: 'Halupa.by - Профиль пользователя',
      description: 'Профиль пользователя, информация о пользователе',
      robots: 'noindex, nofollow'
    },
    canActivate: [AuthGuardService] 
  },
  {
    path: 'create-advert',
    loadChildren: () => import('./pages/create-advert/create-advert.module').then(m => m.CreateAdvertModule),
    data: {
      hideComponents: false,
      title: 'Halupa.by - Добавить объявление',
      description: 'Добавить объявление о продаже или аренде недвижимости',
      robots: 'noindex, nofollow'
    },
    canActivate: [AuthGuardService]
  },
  {
    path: 'flat',
    loadChildren: () => import('./pages/flat/flat.module').then(m => m.FlatModule),
    data: {
      hideComponents: false,
      title: 'Halupa.by - Подробности объявления',
      description: 'Подробности объявления, его характеристики, контакты и стоимость'
    }
  },
  {
    path: 'house',
    loadChildren: () => import('./pages/house/house.module').then(m => m.HouseModule),
    data: {
      hideComponents: false,
      title: 'Halupa.by - Подробности объявления',
      description: 'Подробности объявления, его характеристики, контакты и стоимость'
    }
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabled'
})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
