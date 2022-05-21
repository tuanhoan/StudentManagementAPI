import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: [],
})
export class AppHeaderComponent {
  avatar = localStorage.getItem("avatar");
  constructor(private router: Router) {}
  Logout() {
    localStorage.clear();
    this.router.navigate(["login"]);
  }
}
