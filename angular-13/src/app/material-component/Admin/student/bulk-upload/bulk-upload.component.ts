import { AfterViewInit, Component, OnInit, ViewChild } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { map, startWith } from "rxjs/operators";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-bulk-upload",
  templateUrl: "./bulk-upload.component.html",
  styleUrls: ["./bulk-upload.component.scss"],
})
export class BulkUploadComponent implements OnInit {
  constructor(public httpService: HttpServerService, private router: Router) {}
  options: any;
  myControl = new FormControl();
  filteredOptions!: Observable<string[]>;
  fileName = "";
  teamId = 0;
  files: File[] = [];

  ngOnInit(): void {
    console.log(localStorage);
    this.httpService.Get("Teams").subscribe((data: any) => {
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
    const formData = new FormData();

    Array.from(this.files).map((file, index) => {
      return formData.append("file", file, file.name);
    });

    this.httpService
      .Post("Students/upload-file?TeamId=" + this.teamId, formData, {
        // reportProgress: true,
        // observe: "events",
      })
      .subscribe((data) => {
        console.log(data);
      });
  }
  public onSelectionChange(value: any) {
    this.teamId = value.option.value.id;
  }

  onFileSelected(event: any) {
    this.files = event.target.files;
    Array.from(this.files).map((file) => {
      return (this.fileName += file.name + " |");
    });
  }
}
