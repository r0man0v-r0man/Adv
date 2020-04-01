import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';

import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { UniversalInterceptor } from './universal.interceptor';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { RenderStyleComponent } from './services/render-style/render-style.component';
import { RenderStyleModule } from './services/render-style/render-style.component.module';

@NgModule({
  imports: [
    AppModule,
    ServerModule,
    ModuleMapLoaderModule,
    RenderStyleModule
  ],
  bootstrap: [AppComponent, RenderStyleComponent],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: UniversalInterceptor,
    multi: true
  }]
})
export class AppServerModule {}
