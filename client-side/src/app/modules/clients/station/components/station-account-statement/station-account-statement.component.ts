import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ConfirmationDialogComponent } from '../../../../../shared/components/confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material';


@Component({
  selector: 'app-station-account-statement',
  templateUrl: './station-account-statement.component.html'
})
export class StationAccountStatementComponent {

  // exportList: Array<ExportModel>
  // searchModel: ExportModel = new ExportModel;
  stationId: number;
  stationName: string;
  constructor(private router: Router, private avtiveRoute: ActivatedRoute) {

  }

  ngOnInit() {
    if (this.avtiveRoute.snapshot.params["stationId"]) {
      this.stationId = this.avtiveRoute.snapshot.params["stationId"];
      this.stationName = this.avtiveRoute.snapshot.params["stationName"];
      this.getAllExportByStationId(this.stationId);
    }
  }


  getAllExportByStationId(stationId: number) {
    // this.exportService.getAllExportsByStationId(stationId).subscribe(response => {
    // this.exportList = response.List;
    // }, err => {

    // });
  }

  changePagination(data) {
    // this.searchModel.RecordPerPage = data.recordPerPage;
    // this.searchModel.Page = data.currentPage;
    this.getAllExportByStationId(this.stationId);
  }
}
