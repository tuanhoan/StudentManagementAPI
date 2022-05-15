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
import { ExerciseListComponent } from "./Admin/exercise/exercise-list.component";
import { HomeworkListComponent } from "./Admin/homework/homework-list/homework-list.component";
import { HomeworkDetailComponent } from "./Admin/homework/homework-details/homework-details.component";

export const MaterialRoutes: Routes = [
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
  { path: "view-score", component: ScoreComponent },
  { path: "homework/:id", component: HomeworkDetailComponent, canActivate: [AuthGuard], },
  { path: "add-homework", component: HomeworkComponent, canActivate: [AuthGuard], },
  { path: 'homework-list', component: HomeworkListComponent },
  { path: "exercise-list", component: ExerciseListComponent, canActivate: [AuthGuard], },
];
