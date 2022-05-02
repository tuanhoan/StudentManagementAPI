import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-teacher-details',
  templateUrl: './teacher-details.component.html',
  styleUrls: ['./teacher-details.component.scss']
})
export class TeacherDetailsComponent implements OnInit {

  teachrId:any= 0;

  constructor(
    private _route: ActivatedRoute) {
    }

  ngOnInit(): void {
    this.teachrId = this._route.snapshot.paramMap.get("id");
    console.log(this
      .teachrId);

  }

}
