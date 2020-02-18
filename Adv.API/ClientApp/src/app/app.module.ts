import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgZorroAntdModule, NZ_I18N, ru_RU, NzModalRef } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData } from '@angular/common';
import ru from '@angular/common/locales/ru';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FlatsComponent } from './components/flat/flats/flats.component';
import { AppErrorHandler } from './app-errors/app-error-handler';
import { AddAdvertComponent } from './modal/add-advert/add-advert.component';
import { FlatDetailComponent } from './components/flat/flat-detail/flat-detail.component';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { AddressPipe } from './customPipes/address.pipe';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuardService } from './services/auth-guard.service';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';
import { HttpErrorInterceptor } from './app-errors/http-error.interceptor';
import { CityPipe } from './customPipes/city.pipe';
import { FooterComponent } from './components/footer/footer.component';
import { ProfileComponent } from './drawers/profile/profile.component';
import { DurationPipe } from './customPipes/duration.pipe';
import { EditAdvertComponent } from './modal/edit-advert/edit-advert.component';

registerLocaleData(ru);

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NotFoundComponent,
    NavbarComponent,
    FlatsComponent,
    AddAdvertComponent,
    FlatDetailComponent,
    AddressPipe,
    CityPipe,
    DurationPipe,
    RegisterComponent,
    LoginComponent,
    AccessDeniedComponent,
    FooterComponent,
    ProfileComponent,
    EditAdvertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgZorroAntdModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  entryComponents: [
    AddAdvertComponent,
    ProfileComponent,
    EditAdvertComponent
  ],
  providers: [
    AuthGuardService,
    { 
      provide: NZ_I18N, useValue: ru_RU 
    },
    {
      provide: ErrorHandler, useClass: AppErrorHandler
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
