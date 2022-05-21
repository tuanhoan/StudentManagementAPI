import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { HttpServerService } from "src/app/Services/http-server.service";
import { LoginService } from "src/app/Services/login.service";

@Component({
  selector: "app-login-page",
  templateUrl: "./login-page.component.html",
  styleUrls: ["./login-page.component.css"],
})
export class LoginPageComponent implements OnInit {
  constructor(
    private httpLogin: LoginService,
    private httpServer:HttpServerService,
    private router: Router,
    public snackBar: MatSnackBar
  ) {}

  formLogin = new FormGroup({
    username: new FormControl("", [Validators.required]),
    password: new FormControl("", [
      Validators.required,
      Validators.minLength(8),
    ]),
  });
  user: User = new User();

  ngOnInit(): void {}

  Login() {
    this.user = this.formLogin.value;
    let infor = new Infor();
    this.httpLogin.Login(this.user).subscribe((data) => {
      if (data != null) {
        infor.token = data.item1;
        infor.username = data.item2;
        infor.userId = data.item4;
        infor.role = data.item3[0];

        localStorage.setItem("token", infor.token);
        localStorage.setItem("username", infor.username);
        localStorage.setItem("userId", infor.userId);
        localStorage.setItem("role", infor.role);


        this.snackBar.open("Đăng nhập thành công", undefined, {
          duration: 2000,
        });
        this.router.navigate([""]);

        this.httpServer.Get("Users/"+infor.username).subscribe(user=>{
          console.log(user);

          if(user.teacherNavigation!=null){
            localStorage.setItem("teacherId", user.teacherNavigation.id);
          }
          if(user.studentNavigation!=null){
            localStorage.setItem("studentId", user.studentNavigation.id);
            localStorage.setItem("teamId", user.studentNavigation.teamId);
          }
        });
        console.log(localStorage);

      }
    },(error)=>{
      this.snackBar.open("Sai tên đăng nhập hoặc mật khẩu", undefined, {
        duration: 2000,
      });
    });
  }
}

export class User {
  userName: string = "";
  password: string = "";
}

export class Infor {
  token: string = "";
  username: string = "";
  userId: string = "";
  role: string = "";
}
