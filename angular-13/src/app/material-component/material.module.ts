import 'hammerjs';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { DemoMaterialModule } from '../demo-material-module';
import { CdkTableModule } from '@angular/cdk/table';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MaterialRoutes } from './material.routing';

import { HomeComponent } from './home/home.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatDividerModule } from '@angular/material/divider';
import { TeacherListComponent } from './Admin/teacher-management/teacher-list.component';
import {ClipboardModule} from '@angular/cdk/clipboard';
import { MatTableModule } from '@angular/material/table';
import { TeacherDetailsComponent } from './Admin/teacher-details/teacher-details.component';
import { ProfilesComponent } from './profiles/profiles.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { VideoCallComponent } from './VideoChat/video-call/video-call.component';
import { CallInfoDialogComponent } from './VideoChat/call-info-dialog/call-info-dialog.component';
import { PostNewsFeedComponent } from './Admin/post-newsfeed/post-newsfeed.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { StudentComponent } from './Admin/student/student.component';
import { StudentListComponent } from './Admin/student/student-list/student-list.component';
import { HomeworkComponent } from './Admin/homework/homework.component';
import { ScoreComponent } from './Admin/score-view/score-view.component';
import { ExerciseListComponent } from './Admin/exercise/exercise-list.component';
import { HomeworkListComponent } from './Admin/homework/homework-list/homework-list.component';
import { HomeworkDetailComponent } from './Admin/homework/homework-details/homework-details.component';

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
    CKEditorModule
  ],
  providers: [],
  entryComponents: [],
  declarations: [
    HomeComponent,
    TeacherListComponent,
    TeacherDetailsComponent,
    ProfilesComponent,
    UserProfileComponent,
    VideoCallComponent,
    CallInfoDialogComponent,
    PostNewsFeedComponent,
    StudentComponent,
    StudentListComponent,
    ScoreComponent,
    HomeworkComponent,
    HomeworkListComponent,
    ExerciseListComponent,
    HomeworkDetailComponent
  ]
})

export class MaterialComponentsModule {}
