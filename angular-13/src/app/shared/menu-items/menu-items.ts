import { Injectable } from "@angular/core";

export interface Menu {
  state: string;
  name: string;
  type: string;
  icon: string;
}

const MENUITEMS = [
  {
    state: "home",
    name: "Trang chủ",
    type: "link",
    icon: "home",
    role: "admin",
  },
  {
    state: "teachers",
    name: "Giáo viên",
    type: "link",
    icon: "person",
    role: "admin",
  },
  // { state: 'videocall', name: 'Video Call', type: 'link', icon: 'av_timer', role:'admin' },
  // { state: "dashboard", name: "Dashboard", type: "link", icon: "av_timer" },
  {
    state: "post-newsfeed",
    name: "Bảng tin",
    type: "link",
    icon: "local_library",
    role: "admin",
  },
  {
    state: "students-list",
    name: "Học sinh",
    type: "link",
    icon: "people",
    role: "admin",
  },
  {
    state: "score-list",
    name: "Danh sách điểm",
    type: "link",
    icon: "feed",
    role: "admin",
  },
  {
    state: "homework-list",
    name: "Bài tập",
    type: "link",
    icon: "work",
    role: "admin",
  },
  {
    state: "chart",
    name: "Thống kê",
    type: "link",
    icon: "av_timer",
    role: "admin",
  },
];

@Injectable()
export class MenuItems {
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
}
