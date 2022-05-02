import { Routes } from '@angular/router';
import { ErrorPageComponent } from './error-page/error-page.component';

import { FullComponent } from './layouts/full/full.component';
import { LoginPageComponent } from './Login/login-page/login-page.component';
import { LoginComponent } from './Login/login/login.component';
import { TeacherDetailsComponent } from './material-component/Admin/teacher-details/teacher-details.component';

export const AppRoutes: Routes = [
    {
    path: '',
    component: FullComponent,
    children: [
      {
        path: '',
        redirectTo: '/dashboard',
        pathMatch: 'full'
      },
      {
        path: '',
        loadChildren:
          () => import('./material-component/material.module').then(m => m.MaterialComponentsModule)
      },
      {
        path: 'dashboard',
        loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
      }
    ]
  },
  {
    path:"login", component:LoginPageComponent
  },
  {
    path:"login1", component:LoginPageComponent
  },
  { path: '**', pathMatch: 'full',
    component: ErrorPageComponent }
];
