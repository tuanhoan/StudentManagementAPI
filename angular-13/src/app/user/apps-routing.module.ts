import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NewsfeedComponent } from './blog/newsfeed.component';
import { AboutComponent } from './about/about.component';


import { FullComponent } from './layout/full/full.component';
import { NewsfeedDetailComponent } from './blog/newsfeed-detail/newsfeed-detail.component';


const routes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      { path: '', component: NewsfeedComponent },
      { path: 'blogDetail/:id', component: NewsfeedDetailComponent },
      { path: 'about', component: AboutComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppsRoutingModule { }
