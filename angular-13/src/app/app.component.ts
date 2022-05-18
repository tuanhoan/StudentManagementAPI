import { Component } from '@angular/core';
import { HttpServerService } from './Services/http-server.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private httpService:HttpServerService){
    httpService.Get('ThoiKhoaBieu').subscribe(data=>{

    });
  }
}
