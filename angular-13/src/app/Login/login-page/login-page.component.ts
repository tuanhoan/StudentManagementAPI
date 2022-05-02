import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  constructor(private httpLogin: LoginService,private router: Router) {
  }

  formLogin= new FormGroup({
   username: new FormControl('',[Validators.required]),
   password:new FormControl('',[Validators.required,Validators.minLength(8)]),

 });
 user:User = new User();

 ngOnInit(): void {

 }

//  matcher1 = new MyErrorStateMatcher();

 Login(){
   console.log(this.formLogin.value);
   this.user = this.formLogin.value;
   console.log(this.user);
   console.log("Login");
   let infor = new Infor();
   this.httpLogin.Login(this.user).subscribe((data)=>{
     console.log(data);
     if(data!=null){
       infor.token = data.item1;
       infor.username = data.item2;
       infor.userId = data.item4;
       infor.role = data.item3[0];
       console.log(infor);

       localStorage.setItem("token", infor.token);
       localStorage.setItem("username", infor.username);
       localStorage.setItem("userId", infor.userId);
       localStorage.setItem("role", infor.role);

       console.log(localStorage.getItem("role"));

       this.router.navigate(['']);
     }
   });

 }

}

export class User{
 userName:string="";
 password:string="";
}

export class Infor{
 token: string = "";
 username:string = "";
 userId:string="";
 role:string="";
}
