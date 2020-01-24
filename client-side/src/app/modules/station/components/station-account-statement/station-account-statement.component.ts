import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { IncomeService } from 'src/app/modules/station/services/income.service';
import { IncomeModel } from 'src/app/modules/station/models/income.model';
import { ConfirmationDialogService } from 'src/app/shared/components/confirmation-dialog/service/confirmation-dialog.service';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material';


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
      this.incomeList = response.list;
    }, err => {

    });
  }

  changePagination(data) {
    this.searchModel.recordPerPage = data.recordPerPage;
    this.searchModel.page = data.currentPage;
    this.getAllIncomeBystationId(this.stationId);
  }
}
