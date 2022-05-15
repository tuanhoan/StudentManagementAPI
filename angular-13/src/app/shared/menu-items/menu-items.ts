import { Injectable } from '@angular/core';

export interface Menu {
  state: string;
  name: string;
  type: string;
  icon: string;
}

const MENUITEMS = [
  { state: 'home', name: 'Home', type: 'link', icon: 'av_timer' },
  { state: 'teachers', name: 'Teacher Table', type: 'link', icon: 'av_timer' },
  { state: 'videocall', name: 'Video Call', type: 'link', icon: 'av_timer' },
  { state: 'dashboard', name: 'Dashboard', type: 'link', icon: 'av_timer' },
  { state: 'post-newsfeed', name: 'Newsfeed', type: 'link', icon: 'av_timer' },
  { state: 'students-list', name: 'Students', type: 'link', icon: 'av_timer' },
  { state: 'view-score', name: 'Score', type: 'link', icon: 'av_timer' },
  { state: 'homework-list', name: 'Homework', type: 'link', icon: 'av_timer' },
];

@Injectable()
export class MenuItems {
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
}
