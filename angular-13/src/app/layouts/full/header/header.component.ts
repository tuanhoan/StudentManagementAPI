import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: []
})
export class AppHeaderComponent {

  constructor(private router: Router){}
  Logout(){
    localStorage.removeItem('token');
    console.log(localStorage);
     this.router.navigate(['login']);
  }

}
