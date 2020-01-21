import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { FarmService } from 'src/app/modules/farm/services/farm.service';
import { FarmModel } from 'src/app/modules/farm/models/farm.model';
import { ConfirmationDialogService } from 'src/app/shared/components/confirmation-dialog/service/confirmation-dialog.service';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material';


@Component({
  selector: 'app-farm-list',
  templateUrl: './farm-list.component.html'
})
export class FarmListComponent {

  farmList: Array<FarmModel>
  searchModel: FarmModel = new FarmModel;
  result: string;
  total: number;
  constructor(public dialog: MatDialog, private router: Router, private farmService: FarmService, private confirmationDialogService: ConfirmationDialogService) {

  }

  ngOnInit() {
    this.getAllFarm();
  }


  getAllFarm() {
    debugger;
    this.farmService.getAll(this.searchModel).subscribe(response => {
      this.farmList = response.list;
      this.total = response.total;
    }, err => {

    });
  }

  // public showConfirmDialog(id) {
  //   this.confirmationDialogService.confirm('', 'هل تريد حذف هذا السجل؟')
  //     .then ((confirmed) => this.delete(confirmed, id))
  //     .catch(() => console.log('User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'));
  // }

  showConfirmDialog(id): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent)//, {
    dialogRef.afterClosed().subscribe(dialogResult => {
      this.delete(dialogResult, id);
    });
  }

  private delete(confirmed: boolean, id: number) {
    if (confirmed) {
      this.farmService.delete(id)
        .subscribe((data) => {
          this.getAllFarm();
        })
        , error => {

        }
    }
  }

  changePagination(data) {
    this.searchModel.recordPerPage = data.recordPerPage;
    this.searchModel.page = data.currentPage;
    this.getAllFarm();
  }
}
