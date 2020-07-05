import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { IconsProviderModule } from './icons-provider.module';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';

import { NzNotificationModule } from 'ng-zorro-antd/notification';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { ru_RU } from 'ng-zorro-antd/i18n';
import { registerLocaleData, CommonModule } from '@angular/common';
import ru from '@angular/common/locales/ru';
import { AppErrorHandler } from './errors/appErrorHandler';
import { HttpErrorInterceptor } from './errors/httpError.interceptor';
import { NzMessageModule, NzMessageService } from 'ng-zorro-antd/message';
import { AuthGuardService } from './services/auth-guard.service';

// SSR
import { NgtUniversalModule } from '@ng-toolkit/universal';
import {AngularYandexMapsModule, IConfig} from 'angular8-yandex-maps';


const mapConfig: IConfig = {
  apikey: '85e03f02-25be-40b3-971e-733f2a03e620',
  lang: 'ru_RU',
  coordorder: 'latlong'
};

registerLocaleData(ru);

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    AppRoutingModule,
    IconsProviderModule,
    NzLayoutModule,
    NzMenuModule,
    NzNotificationModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NzMessageModule,
    NgtUniversalModule,
    CommonModule,
    AngularYandexMapsModule.forRoot(mapConfig)
  ],
  providers: [
    Title,
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
