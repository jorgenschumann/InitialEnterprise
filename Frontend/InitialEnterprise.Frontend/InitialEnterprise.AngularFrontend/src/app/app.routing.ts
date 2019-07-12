import { AddressDetailComponent } from './shared/address/address-detail/address-detail.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { CurrencyListComponent } from './currency/currency-list/currency-list.component';
import { PersonListComponent } from './person/person-list/person-list.component';
import { PersonDetailComponent } from './person/person-detail/person-detail.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { Role } from './shared/models/user.types';

const appRoutes: Routes = [
  {
      path: '',
      component: HomeComponent,
      canActivate: [AuthGuard]
  },
  {
    path: 'currencies',
    component: CurrencyListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'users',
    component: UserListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'persons',
    component: PersonListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'persons/:id',
    component: PersonDetailComponent
  },
  {
    path: 'persons/:personId/addresses/:id',
    component: AddressDetailComponent
  },
  {
      path: 'admin',
      component: AdminComponent,
      canActivate: [AuthGuard],
      data: { roles: [Role.Admin] }
  },
  {
      path: 'login',
      component: UserLoginComponent
  },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
