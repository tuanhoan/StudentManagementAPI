import { Component, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { map, startWith } from "rxjs/operators";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-student",
  templateUrl: "./student.component.html",
  styleUrls: ["./student.component.scss"],
})
export class StudentComponent implements OnInit {
  constructor(public httpService: HttpServerService) {}

  isBulkUpload = false;
  myControl = new FormControl();
  options: any;
  filteredOptions!: Observable<string[]>;

  student: Student = new Student();

  ngOnInit(): void {
    this.httpService.Get("Teams").subscribe((data) => {
      console.log(data);
      this.options = data;

      this.filteredOptions = this.myControl.valueChanges.pipe(
        startWith(""),
        map((value) => (typeof value === "string" ? value : value.name)),
        map((name) => (name ? this._filter(name) : this.options.slice()))
      );
    });
  }

  private _filter(name: string): any {
    const filterValue = name.toLowerCase();

    return this.options.filter((option: any) =>
      option.name.toLowerCase().includes(filterValue)
    );
  }
  displayFn(options: any): string {
    return options && options.name ? options.name : "";
  }

  public Submit() {
    this.httpService.Post("Students", this.student).subscribe((data) => {
      console.log(data);
      let teamId = data.teamId;
      this.student = new Student();
      this.student.teamId = data.teamId;
    });
  }
  public onSelectionChange(value: any) {
    this.student.teamId = value.option.value.id;
  }
}

export class Student {
  fullName: string = "";
  email: string = "";
  birthday: Date = new Date();
  phoneNumber: string = "";
  teamId: number = 0;
}
