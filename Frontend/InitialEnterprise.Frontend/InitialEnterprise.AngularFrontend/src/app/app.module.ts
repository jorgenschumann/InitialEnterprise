import { AddressListItemComponent } from './shared/address/address-list-item/address-list-item.component';
import { AddressDetailComponent } from './shared/address/address-detail/address-detail.component';
import { AddressListComponent } from './shared/address/address-list/address-list.component';
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
import { routing } from './app.routing';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { AdminComponent } from './admin/admin.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserAvatarComponent } from './user/user-avatar/user-avatar.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { CurrencyDetailComponent } from './currency/currency-detail/currency-detail.component';
import { CurrencyListComponent } from './currency/currency-list/currency-list.component';
import { PersonListComponent } from './person/person-list/person-list.component';
import { PersonListItemComponent } from './person/person-list-item/person-list-item.component';
import { PersonDetailComponent } from './person/person-detail/person-detail.component';
import { PaymentComponent } from './shared/payment/payment.component';
import { ConfirmDialogComponent } from './shared/components/confirm-dialog/confirm-dialog.component';
import { CamelCasePipe } from './shared/pipes/camel-case.pipe';
import { UploadComponent } from './shared/components/upload/upload.component';
import { JsonModelComponent } from './shared/components/json-model/JsonModel.component';
import { PopoverComponent } from './shared/components/popover/popover.component';

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
      CurrencyListComponent,
      UserLoginComponent,
      AdminComponent,
      UserListComponent,
      UserAvatarComponent,
      UserDetailComponent,
      CurrencyDetailComponent,
      ConfirmDialogComponent,
      CamelCasePipe,
      UploadComponent,
      PersonListComponent,
      PersonListItemComponent,
      PersonDetailComponent,
      JsonModelComponent,
      AddressListComponent,
      AddressListItemComponent,
      AddressDetailComponent,
      PaymentComponent,
      PopoverComponent,
   ],
   entryComponents: [
      UserListComponent,
      UserDetailComponent,
      CurrencyDetailComponent,
      ConfirmDialogComponent
   ],
   bootstrap: [
      AppComponent
   ]
})

export class AppModule {}
