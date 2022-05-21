import "hammerjs";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { HttpClientModule } from "@angular/common/http";
import { CommonModule } from "@angular/common";

import { DemoMaterialModule } from "../demo-material-module";
import { CdkTableModule } from "@angular/cdk/table";

import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { FlexLayoutModule } from "@angular/flex-layout";

import { MaterialRoutes } from "./material.routing";

import { HomeComponent } from "./home/home.component";
import { DragDropModule } from "@angular/cdk/drag-drop";
import { MatDividerModule } from "@angular/material/divider";
import { TeacherListComponent } from "./Admin/teacher-management/teacher-list.component";
import { ClipboardModule } from "@angular/cdk/clipboard";
import { MatTableModule } from "@angular/material/table";
import { TeacherDetailsComponent } from "./Admin/teacher-details/teacher-details.component";
import { UserProfileComponent } from "./user-profile/user-profile.component";
import { VideoCallComponent } from "./VideoChat/video-call/video-call.component";
import { CallInfoDialogComponent } from "./VideoChat/call-info-dialog/call-info-dialog.component";
import { PostNewsFeedComponent } from "./Admin/post-newsfeed/post-newsfeed.component";
import { CKEditorModule } from "@ckeditor/ckeditor5-angular";
import { StudentComponent } from "./Admin/student/student.component";
import { StudentListComponent } from "./Admin/student/student-list/student-list.component";
import { HomeworkComponent } from "./Admin/homework/homework.component";
import { ScoreComponent } from "./Admin/score-view/score-view.component";
import { HomeworkListComponent } from "./Admin/homework/homework-list/homework-list.component";
import { HomeworkDetailComponent } from "./Admin/homework/homework-details/homework-details.component";
import { CommentComponent } from "../User/comment/comment.component";
import { ExerciseComponent } from "./Admin/homework/exercise/exercise.component";
import { TeamListComponent } from "./Admin/homework/team-list/team-list.component";
import { MatGridListModule } from "@angular/material/grid-list";
import { BulkUploadComponent } from "./Admin/student/bulk-upload/bulk-upload.component";
import { ScoreItemComponent } from "./Admin/score-view/score-item/score-item.component";
import { ScoreListComponent } from "./Admin/score-view/score-list/score-list.component";
import { ScoreStudentComponent } from "./Admin/score-view/score-student/score-student.component";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(MaterialRoutes),
    DemoMaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    CdkTableModule,
    DragDropModule,
    MatDividerModule,
    MatTableModule,
    ClipboardModule,
    CKEditorModule,
    MatGridListModule
  ],
  providers: [],
  entryComponents: [],
  declarations: [
    HomeComponent,
    TeacherListComponent,
    TeacherDetailsComponent,
    UserProfileComponent,
    VideoCallComponent,
    CallInfoDialogComponent,
    PostNewsFeedComponent,
    StudentComponent,
    StudentListComponent,
    ScoreComponent,
    HomeworkComponent,
    HomeworkListComponent,
    ExerciseComponent,
    HomeworkDetailComponent,
    TeamListComponent,
    BulkUploadComponent,
    ScoreItemComponent,
    ScoreListComponent,
    ScoreStudentComponent
  ],
exports:[ScoreComponent, HomeworkDetailComponent]
})
export class MaterialComponentsModule {}
