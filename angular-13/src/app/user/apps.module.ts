import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { AppsRoutingModule } from "./apps-routing.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppsComponent } from "./apps.component";
import { NewsfeedComponent } from "./blog/newsfeed.component";
import { AboutComponent } from "./about/about.component";
import { NewsfeedDetailComponent } from "./blog/newsfeed-detail/newsfeed-detail.component";

import { ServiceblogService } from "./blog/blog-service.service";
import { RelayOnComponent } from "./about/About-Components/relay-on/relay-on.component";
import { TopContentComponent } from "./about/About-Components/top-content/top-content.component";

import { FullComponent } from "./layout/full/full.component";

import { BannerComponent } from "./shared/banner/banner.component";
import { BannerNavigationComponent } from "./shared/banner-navigation/banner-navigation.component";
import { FooterComponent } from "./shared/footer/footer.component";
import { CommentComponent } from "./comment/comment.component";
import { UserScoreComponent } from "./user-score/user-score.component";
import { MatTableModule } from "@angular/material/table";
import { MaterialComponentsModule } from "../material-component/material.module";
import { UserHomeworkComponent } from "./user-homework/user-homework.component";
import { UserHomeworkDetailsComponent } from "./user-homework/user-homework-details/user-homework-details.component";
import { UserHomeworkListComponent } from "./user-homework/user-homework-list/user-homework-list.component";
import { UserProfileComponent } from "./profile/user-profile.component";

@NgModule({
  declarations: [
    AppsComponent,
    NewsfeedComponent,
    AboutComponent,
    NewsfeedDetailComponent,
    RelayOnComponent,
    TopContentComponent,
    FullComponent,
    BannerComponent,
    // BannerContentComponent,
    BannerNavigationComponent,
    FooterComponent,
    CommentComponent,
    UserScoreComponent,
    UserHomeworkComponent,
    UserHomeworkDetailsComponent,
    UserHomeworkListComponent,
    UserProfileComponent,
  ],
  imports: [
    CommonModule,
    AppsRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatTableModule,
    MaterialComponentsModule,
  ],
  providers: [ServiceblogService],
  exports: [CommentComponent],
})
export class AppsModule {}
