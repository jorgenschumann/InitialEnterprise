import { UserListComponent } from './user/user-list/user-list.component';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { AuthGuard } from './core/guards/auth.guard';
import { Role } from './models/user.types';
import { CurrencyListComponent } from './currency/currency-list/currency-list.component';

const appRoutes: Routes = [
  {
      path: '',
      component: HomeComponent,
      canActivate: [AuthGuard]
  },
  {
    path: 'currency',
    component: CurrencyListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'userlist',
    component: UserListComponent,
    canActivate: [AuthGuard]
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
