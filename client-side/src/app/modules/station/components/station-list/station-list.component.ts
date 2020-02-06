import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { StationService } from 'src/app/modules/station/services/station.service';
import { StationModel } from 'src/app/modules/station/models/station.model';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material';


@Component({
  selector: 'app-station-list',
  templateUrl: './station-list.component.html'
})
export class StationListComponent {

  stationList: Array<StationModel>
  searchModel: StationModel = new StationModel;
  result: string;
  total: number;
  constructor(public dialog: MatDialog, private router: Router, private stationService: StationService) {

  }

  ngOnInit() {
    this.getAllStation();
  }


  getAllStation() {
    debugger;
    this.stationService.getAll(this.searchModel).subscribe(response => {
      this.stationList = response.List;
      this.total = response.total;
    }, err => {

    });
  }

  showConfirmDialog(id): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent)//, {
    dialogRef.afterClosed().subscribe(dialogResult => {
      this.delete(dialogResult, id);
    });
  }

  private delete(confirmed: boolean, id: number) {
    if (confirmed) {
      this.stationService.delete(id)
        .subscribe((data) => {
          this.getAllStation();
        })
        , error => {

        }
    }
  }

  changePagination(data) {
    this.searchModel.RecordPerPage = data.recordPerPage;
    this.searchModel.Page = data.currentPage;
    this.getAllStation();
  }
}
