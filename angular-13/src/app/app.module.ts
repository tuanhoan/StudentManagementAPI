
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { LocationStrategy, PathLocationStrategy } from '@angular/common';
import { AppRoutes } from './app.routing';
import { AppComponent } from './app.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

import { FlexLayoutModule } from '@angular/flex-layout';
import { FullComponent } from './layouts/full/full.component';
import { AppHeaderComponent } from './layouts/full/header/header.component';
import { AppSidebarComponent } from './layouts/full/sidebar/sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DemoMaterialModule } from './demo-material-module';

import { SharedModule } from './shared/shared.module';
import { SpinnerComponent } from './shared/spinner.component';
import { LoginComponent } from './Login/login/login.component';
import { AuthGuard } from './auth.guard';
import { ErrorPageComponent } from './error-page/error-page.component';
import { LoginPageComponent } from './Login/login-page/login-page.component';
import { RegisterPageComponent } from './Login/register-page/register-page.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormatContentPipe } from './Pipe/format-content.pipe';
import { ProfileComponent } from './common/profile/profile.component';
import { ExampleComponent } from './example/example.component';
import { CommentComponent } from './User/comment/comment.component';
import { AuthTeacherGuard } from './auth-teacher.guard';

@NgModule({
  declarations: [
    AppComponent,
    FullComponent,
    AppHeaderComponent,
    SpinnerComponent,
    AppSidebarComponent,
    LoginComponent,
    ErrorPageComponent,
    LoginPageComponent,
    RegisterPageComponent,
    FormatContentPipe,
    ProfileComponent,
    ExampleComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    FormsModule,
    FlexLayoutModule,
    HttpClientModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forRoot(AppRoutes),
    NgbModule,
    CKEditorModule
  ],
  providers: [
    {
      provide: LocationStrategy,
      useClass: PathLocationStrategy
    },
    AuthGuard,
    AuthTeacherGuard
  ],
  bootstrap: [AppComponent],

})
export class AppModule {}
