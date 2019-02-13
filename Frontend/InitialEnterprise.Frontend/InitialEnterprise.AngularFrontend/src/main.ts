import './polyfills';

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { ValidationService } from './infrastructure/validation.service';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

export function getApiUrl() {
  return 'http://localhost:63928/api';
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: 'API_URL', useFactory: getApiUrl, deps: [] }
];

platformBrowserDynamic(providers).bootstrapModule(AppModule).then(ref => {
  // // Ensure Angular destroys itself on hot reloads.
  // if (window.ngRef) {
  //   window.ngRef.destroy();
  // }
  // window.ngRef = ref;

  // Otherwise, log the boot error
}).catch(err => console.error(err));
