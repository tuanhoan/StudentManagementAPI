import { Injectable } from '@angular/core';

export interface Menu {
  state: string;
  name: string;
  type: string;
  icon: string;
}

const MENUITEMS = [
  { state: 'home', name: 'Trang chủ', type: 'link', icon: 'av_timer' },
  { state: 'teachers', name: 'Giáo viên', type: 'link', icon: 'av_timer' },
  { state: 'videocall', name: 'Video Call', type: 'link', icon: 'av_timer' },
  { state: 'dashboard', name: 'Dashboard', type: 'link', icon: 'av_timer' },
  { state: 'post-newsfeed', name: 'Bảng tin', type: 'link', icon: 'av_timer' },
  { state: 'students-list', name: 'Học sinh', type: 'link', icon: 'av_timer' },
  { state: 'view-score', name: 'Điểm', type: 'link', icon: 'av_timer' },
  { state: 'homework-list', name: 'Bài tập', type: 'link', icon: 'av_timer' },
];

@Injectable()
export class MenuItems {
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
}
