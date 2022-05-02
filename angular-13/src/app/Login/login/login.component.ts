import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { LoginService } from 'src/app/Services/login.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private httpLogin: LoginService) {
   }

   formLogin= new FormGroup({
    username: new FormControl('',[Validators.required]),
    password:new FormControl('',[Validators.required,Validators.minLength(8)]),

  });
  user:User = new User();

  ngOnInit(): void {

  }

  matcher1 = new MyErrorStateMatcher();

  Login(){
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

export class MyErrorStateMatcher implements ErrorStateMatcher {

  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {

    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
