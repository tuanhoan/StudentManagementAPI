import { Routes } from "@angular/router";
import { AuthTeacherGuard } from "./auth-teacher.guard";
import { ErrorPageComponent } from "./error-page/error-page.component";

import { FullComponent } from "./layouts/full/full.component";
import { LoginPageComponent } from "./Login/login-page/login-page.component";
import { LoginComponent } from "./Login/login/login.component";
import { TeacherDetailsComponent } from "./material-component/Admin/teacher-details/teacher-details.component";

export const AppRoutes: Routes = [
  {
    path: "",
    component: FullComponent,
    children: [
      {
        path: "",
        redirectTo: "/home",
        pathMatch: "full",
      },
      {
        path: "",

        loadChildren: () =>
          import("./material-component/material.module").then(
            (m) => m.MaterialComponentsModule
          ),
      },
      {
        path: "dashboard",
        loadChildren: () =>
          import("./dashboard/dashboard.module").then((m) => m.DashboardModule),
      },
    ],
  },
  {
    path: "login",
    component: LoginPageComponent,
  },
  {
    path: "login1",
    component: LoginPageComponent,
  },
  {
    path: "",
    children: [
      {
        path: "user",
        loadChildren: () =>
          import("./User/apps.module").then((m) => m.AppsModule),
      },
    ],
  },
  { path: "**", pathMatch: "full", component: ErrorPageComponent },
];
