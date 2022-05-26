import { Component, OnInit } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-chart",
  templateUrl: "./chart.component.html",
  styleUrls: ["./chart.component.css"],
})
export class ChartComponent implements OnInit {
  constructor(private readonly httpsService: HttpServerService) {}

  dataScores: any = [];
  ngOnInit() {
    this.httpsService.Get("Scores/statistical").subscribe((data) => {
      console.log(data);
      data.forEach((element: any) => {
        data = {
          name:element.name,
          data: [
            ["8-5-10", element.yeu],
            ["6.5-8.5", element.tb],
            ["5-6.5", element.kha],
            ["0-5", element.gioi],
          ],
        };
        this.dataScores.push(data);
      });

      console.log(this.dataScores);
    });
  }

  title = "Danh sách điểm lớp: ";
  type = "PieChart";
  data = [
    ["8-5-10", 45.0],
    ["6.5-8.5", 25.0],
    ["5-6.5", 10.0],
    ["0-5", 20.0],
  ];
  columnNames = ["Browser", "Percentage"];
  options = {};
  width = 350;
  height = 350;
}
