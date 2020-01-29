import './polyfills';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

export function getApiUrl() {
  return '';//return 'http://localhost:55555/api';
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: 'API_URL', useFactory: getApiUrl, deps: [] }
];


platformBrowserDynamic(providers).bootstrapModule(AppModule).then(ref => {
}).catch(err => console.error(err));
