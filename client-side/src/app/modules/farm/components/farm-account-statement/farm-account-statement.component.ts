import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ExportService } from 'src/app/modules/farm/services/export.service';
import { ExportModel } from 'src/app/modules/farm/models/export.model';
import { ConfirmationDialogService } from 'src/app/shared/components/confirmation-dialog/service/confirmation-dialog.service';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material';


@Component({
  selector: 'app-farm-account-statement',
  templateUrl: './farm-account-statement.component.html'
})
export class FarmAccountStatementComponent {

  exportList: Array<ExportModel>
  searchModel: ExportModel = new ExportModel;
  farmId: number;
  farmName: string;
  constructor(private router: Router, private exportService: ExportService, private avtiveRoute: ActivatedRoute) {

  }

  ngOnInit() {
    if (this.avtiveRoute.snapshot.params["farmId"]) {
      this.farmId = this.avtiveRoute.snapshot.params["farmId"];
      this.farmName = this.avtiveRoute.snapshot.params["farmName"];
      this.getAllExportByFarmId(this.farmId);
    }
  }


  getAllExportByFarmId(farmId: number) {
    this.exportService.getAllExportsByFarmId(farmId).subscribe(response => {
      this.exportList = response.List;
    }, err => {

    });
  }

  changePagination(data) {
    this.searchModel.RecordPerPage = data.recordPerPage;
    this.searchModel.Page = data.currentPage;
    this.getAllExportByFarmId(this.farmId);
  }
}
