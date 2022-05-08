import { Routes } from "@angular/router";

import { ButtonsComponent } from "./buttons/buttons.component";
import { GridComponent } from "./grid/grid.component";
import { ListsComponent } from "./lists/lists.component";
import { MenuComponent } from "./menu/menu.component";
import { TabsComponent } from "./tabs/tabs.component";
import { StepperComponent } from "./stepper/stepper.component";
import { ExpansionComponent } from "./expansion/expansion.component";
import { ChipsComponent } from "./chips/chips.component";
import { ToolbarComponent } from "./toolbar/toolbar.component";
import { ProgressSnipperComponent } from "./progress-snipper/progress-snipper.component";
import { ProgressComponent } from "./progress/progress.component";
import { DialogComponent } from "./dialog/dialog.component";
import { TooltipComponent } from "./tooltip/tooltip.component";
import { SnackbarComponent } from "./snackbar/snackbar.component";
import { SliderComponent } from "./slider/slider.component";
import { SlideToggleComponent } from "./slide-toggle/slide-toggle.component";
import { HomeComponent } from "./home/home.component";
import { TeacherListComponent } from "./Admin/teacher-management/teacher-list.component";
import { TeacherDetailsComponent } from "./Admin/teacher-details/teacher-details.component";
import { AuthGuard } from "../auth.guard";
import { UserProfileComponent } from "./user-profile/user-profile.component";
import { VideoCallComponent } from "./VideoChat/video-call/video-call.component";
import { PostNewsFeedComponent } from "./Admin/post-newsfeed/post-newsfeed.component";
import { ProfileComponent } from "../common/profile/profile.component";
import { StudentComponent } from "./Admin/student/student.component";
import { StudentListComponent } from "./Admin/student/student-list/student-list.component";

export const MaterialRoutes: Routes = [
  {
    path: "button",
    component: ButtonsComponent,
  },
  {
    path: "grid",
    component: GridComponent,
  },
  {
    path: "lists",
    component: ListsComponent,
  },
  {
    path: "menu",
    component: MenuComponent,
  },
  {
    path: "tabs",
    component: TabsComponent,
  },
  {
    path: "stepper",
    component: StepperComponent,
  },
  {
    path: "expansion",
    component: ExpansionComponent,
  },
  {
    path: "chips",
    component: ChipsComponent,
  },
  {
    path: "toolbar",
    component: ToolbarComponent,
  },
  {
    path: "progress-snipper",
    component: ProgressSnipperComponent,
  },
  {
    path: "progress",
    component: ProgressComponent,
  },
  {
    path: "dialog",
    component: DialogComponent,
  },
  {
    path: "tooltip",
    component: TooltipComponent,
  },
  {
    path: "snackbar",
    component: SnackbarComponent,
  },
  {
    path: "slider",
    component: SliderComponent,
  },
  {
    path: "slide-toggle",
    component: SlideToggleComponent,
  },
  {
    path: "home",
    component: HomeComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "teachers",
    children: [
      { path: "", component: TeacherListComponent },
      {
        path: ":id",
        component: TeacherDetailsComponent,
        pathMatch: "full",
      },
    ],
  },
  {
    path: "profile",
    component: ProfileComponent,
  },
  { path: "videocall", component: VideoCallComponent },
  { path: "post-newsfeed", component: PostNewsFeedComponent },
  { path: "students", component: StudentComponent },
  { path: "students-list", component: StudentListComponent },
];
