import { NgModule } from '@angular/core';
import { ServerModule, ServerTransferStateModule } from '@angular/platform-server';

import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { RenderStyleComponent } from './services/render-style/render-style.component';
import { RenderStyleModule } from './services/render-style/render-style.component.module';
import { NZ_I18N, NzI18nModule, ru_RU } from 'ng-zorro-antd/i18n';

@NgModule({
  imports: [
    AppModule,
    ServerModule,
    ModuleMapLoaderModule,
    RenderStyleModule,
    ServerTransferStateModule,
    NzI18nModule
  ],
  bootstrap: [AppComponent, RenderStyleComponent],
  providers: [
    { provide: NZ_I18N, useValue: ru_RU }
  ]
})
export class AppServerModule {}
