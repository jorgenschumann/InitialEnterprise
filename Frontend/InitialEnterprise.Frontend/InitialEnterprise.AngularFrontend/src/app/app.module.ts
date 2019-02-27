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
import { Routes } from '@angular/router';
import { CurrencyComponent } from './currency/currency.component';
import { routing } from './app.routing';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { AdminComponent } from './admin/admin.component';
import { JwtInterceptor, ErrorInterceptor } from './core/interceptor';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserAvatarComponent } from './user/user-avatar/user-avatar.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';

@NgModule({
   imports: [
      BrowserModule,
      FormsModule,
      ReactiveFormsModule,
      HttpClientModule,
      NgbModule,
      ReactiveFormsModule,
      routing
   ],
   declarations: [
      AppComponent,
      NgbdDatepickerBasic,
      NavMenuComponent,
      HomeComponent,
      CurrencyComponent,
      UserLoginComponent,
      AdminComponent,
      UserListComponent,
      UserAvatarComponent,
      UserDetailComponent
   ],
   entryComponents: [
     UserListComponent,
     UserDetailComponent
    ],
   providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
   bootstrap: [
      AppComponent
   ]
})

export class AppModule {}
