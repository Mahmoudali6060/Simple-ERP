import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { IncomeService } from 'src/app/modules/station/services/income.service';
import { IncomeModel } from 'src/app/modules/station/models/income.model';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material';
import * as jsPDF from 'jspdf';


@Component({
  selector: 'app-station-account-statement',
  templateUrl: './station-account-statement.component.html'
})

export class StationAccountStatementComponent {

  incomeList: Array<IncomeModel>
  searchModel: IncomeModel = new IncomeModel;
  stationId: number;
  stationName: string;

  constructor(private router: Router, private incomeService: IncomeService, private avtiveRoute: ActivatedRoute) {

  }

  ngOnInit() {
    if (this.avtiveRoute.snapshot.params["stationId"]) {
      this.stationId = this.avtiveRoute.snapshot.params["stationId"];
      this.stationName = this.avtiveRoute.snapshot.params["stationName"];
      this.getAllIncomeBystationId(this.stationId);
    }
  }


  getAllIncomeBystationId(stationId: number) {
    this.incomeService.getAllIncomesByStationId(stationId).subscribe(response => {
      this.incomeList = response.List;
    }, err => {

    });
  }

  changePagination(data) {
    this.searchModel.RecordPerPage = data.recordPerPage;
    this.searchModel.Page = data.currentPage;
    this.getAllIncomeBystationId(this.stationId);
  }

  DownloadReport() {
    let row: any[] = []
    let rowD: any[] = []
    let col = ['Date']; // initialization for headers
    let title = "Sample Report" // title of report
    for (let a = 0; a < this.incomeList.length; a++) {
      row.push(this.incomeList[a].Date)
      // row.push(this.incomeList[a].title)
      // row.push(this.incomeList[a].total)
      // row.push(this.incomeList[a].description)
      rowD.push(row);
      row = [];
    }
    this.getReport(col, rowD, title);

   
  }

  getReport(col: any[], rowD: any[], title: any) {
    const totalPagesExp = "{total_pages_count_string}";
    let pdf = new jsPDF('l', 'pt', 'legal');
    pdf.setTextColor(51, 156, 255);
    pdf.text("Date", 450, 40);
    // pdf.text("Email:", 450, 60); // 450 here is x-axis and 80 is y-axis
    // pdf.text("Phone:", 450, 80); // 450 here is x-axis and 80 is y-axis
    pdf.text("" + title, 435, 100);  //
    pdf.setLineWidth(1.5);
    pdf.line(5, 107, 995, 107)
    var pageContent = function (data) {
      // HEADER

      // FOOTER
      var str = "Page " + data.pageCount;
      // Total page number plugin only available in jspdf v1.0+
      if (typeof pdf.putTotalPages === 'function') {
        str = str + " of " + totalPagesExp;
      }
      pdf.setFontSize(10);
      var pageHeight = pdf.internal.pageSize.height || pdf.internal.pageSize.getHeight();
      pdf.text(str, data.settings.margin.left, pageHeight - 10); // showing current page number
    };
    pdf.autoTable(col, rowD,
      {
        addPageContent: pageContent,
        margin: { top: 110 },
      });

    //for adding total number of pages // i.e 10 etc
    if (typeof pdf.putTotalPages === 'function') {
      pdf.putTotalPages(totalPagesExp);
    }

    pdf.save(title + '.pdf');
  }
}
