import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NewsfeedComponent } from './blog/newsfeed.component';
import { AboutComponent } from './about/about.component';


import { FullComponent } from './layout/full/full.component';
import { NewsfeedDetailComponent } from './blog/newsfeed-detail/newsfeed-detail.component';
import { ScoreComponent } from '../material-component/Admin/score-view/score-view.component';
import { UserScoreComponent } from './user-score/user-score.component';
import { UserHomeworkComponent } from './user-homework/user-homework.component';
import { UserHomeworkDetailsComponent } from './user-homework/user-homework-details/user-homework-details.component';
import { UserHomeworkListComponent } from './user-homework/user-homework-list/user-homework-list.component';


const routes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      { path: '', component: NewsfeedComponent },
      { path: 'blogDetail/:id', component: NewsfeedDetailComponent },
      { path: 'about', component: AboutComponent },
      { path: 'score', component: UserScoreComponent },
      { path: 'homework', component: UserHomeworkComponent },
      { path: 'homework/list/:id', component: UserHomeworkListComponent },
      { path: 'homework/details/:id', component: UserHomeworkDetailsComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppsRoutingModule { }
