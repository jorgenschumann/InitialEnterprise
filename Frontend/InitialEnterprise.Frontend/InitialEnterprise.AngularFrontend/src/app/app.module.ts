import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { NgbdDatepickerBasic } from './datepicker-basic';
import { RouterModule } from '@angular/router';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CurrencyComponent } from './currency/currency.component';
import { UserSigninComponent } from './user-signin/user-signin.component';
import { Routes } from '@angular/router';
import { UserRegisterComponent } from './user-register/user-register.component';
import { UserSigninService } from './user-signin/user-signin.service';
import { UserAuthenticationService } from './user-signin/user-authentication.service';
import { ErrorInterceptor } from 'src/infrastructure/interceptor/error-interceptor';
import { JwtInterceptor } from 'src/infrastructure/interceptor/jwt-interceptor';
import { Routing } from './app-route.routing';

@NgModule({
   imports: [
      BrowserModule,
      FormsModule,
      ReactiveFormsModule,
      HttpClientModule,
      NgbModule,
      ReactiveFormsModule,
      Routing,
      RouterModule.forRoot([
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'home', component: HomeComponent },
        { path: 'currency', component: CurrencyComponent },
        { path: 'nav-menu', component: NavMenuComponent },
        { path: 'user-signin', component: UserSigninComponent },
        { path: 'user-register', component: UserRegisterComponent },
      ])
   ],
   declarations: [
      AppComponent,
      NgbdDatepickerBasic,
      NavMenuComponent,
      HomeComponent,
      CounterComponent,
      FetchDataComponent,
      CurrencyComponent,
      UserSigninComponent,
      UserRegisterComponent
   ],
   providers: [
    UserSigninService,
    UserAuthenticationService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
   bootstrap: [
      AppComponent
   ]
})

export class AppModule {}
