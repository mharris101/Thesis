import '@angular/compiler';
import { enableProdMode } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';

import { AppComponent } from './app/app.component';

if ((window as any).ENABLE_PROD_MODE) {
  enableProdMode();
}

//bootstrapApplication(AppComponent);




platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
