import { Routes } from "@angular/router";

import { HomeComponent } from "./home/home.component";
import { TeacherListComponent } from "./Admin/teacher-management/teacher-list.component";
import { TeacherDetailsComponent } from "./Admin/teacher-details/teacher-details.component";
import { AuthGuard } from "../auth.guard";
import { VideoCallComponent } from "./VideoChat/video-call/video-call.component";
import { PostNewsFeedComponent } from "./Admin/post-newsfeed/post-newsfeed.component";
import { ProfileComponent } from "../common/profile/profile.component";
import { StudentComponent } from "./Admin/student/student.component";
import { StudentListComponent } from "./Admin/student/student-list/student-list.component";
import { HomeworkComponent } from "./Admin/homework/homework.component";
import { ScoreComponent } from "./Admin/score-view/score-view.component";
import { HomeworkListComponent } from "./Admin/homework/homework-list/homework-list.component";
import { HomeworkDetailComponent } from "./Admin/homework/homework-details/homework-details.component";
import { TeamListComponent } from "./Admin/homework/team-list/team-list.component";
import { ScoreListComponent } from "./Admin/score-view/score-list/score-list.component";
import { ScoreStudentComponent } from "./Admin/score-view/score-student/score-student.component";
import { ChartComponent } from "./Admin/chart/chart.component";
import { AuthTeacherGuard } from "../auth-teacher.guard";

export const MaterialRoutes: Routes = [
  {
    path: "home",
    component: HomeComponent,
    canActivate: [AuthTeacherGuard],
  },
  {
    path: "teachers",
    canActivate: [AuthTeacherGuard],
    children: [
      {
        path: "",
        component: TeacherListComponent,
      },
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
  {
    path: "videocall",
    component: VideoCallComponent,
    canActivate: [AuthTeacherGuard],
  },
  {
    path: "post-newsfeed",
    component: PostNewsFeedComponent,
    canActivate: [AuthTeacherGuard],
  },
  {
    path: "students",
    component: StudentComponent,
    canActivate: [AuthTeacherGuard],
  },
  {
    path: "students-list",
    component: StudentListComponent,
    canActivate: [AuthTeacherGuard],
  },
  { path: "view-score", component: ScoreComponent },
  {
    path: "homework/:id",
    component: HomeworkDetailComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "add-homework/:id",
    component: HomeworkComponent,
    canActivate: [AuthTeacherGuard],
  },
  { path: "homework-list/:id", component: HomeworkListComponent },
  { path: "homework-list", component: TeamListComponent },
  { path: "score-list", component: ScoreListComponent },
  {
    path: "score-list/:subjectid/:id",
    component: ScoreStudentComponent,
    canActivate: [AuthTeacherGuard],
  },
  { path: "chart", component: ChartComponent, canActivate: [AuthTeacherGuard] },
];
