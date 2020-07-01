import 'zone.js/dist/zone-node';
import 'reflect-metadata';
import { renderModule } from '@angular/platform-server';
import { APP_BASE_HREF } from '@angular/common';
import { enableProdMode } from '@angular/core';
import { provideModuleMap } from '@nguniversal/module-map-ngfactory-loader';
import { createServerRenderer } from 'aspnet-prerendering';
import { AppServerModule } from './app/app.server.module';

enableProdMode();

export default createServerRenderer(params => {
  const { LAZY_MODULE_MAP } = (module as any).exports;
  const options = {
    document: params.data.originalHtml,
    url: params.url,
    extraProviders: [
      provideModuleMap(LAZY_MODULE_MAP),
      { provide: APP_BASE_HREF, useValue: params.baseUrl },
      { provide: 'BASE_URL', useValue: params.origin + params.baseUrl }
    ]
  };

  const renderPromise = renderModule(AppServerModule, options);

  return renderPromise.then(html => ({ html }));
});