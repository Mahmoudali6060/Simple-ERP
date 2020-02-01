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
  selector: 'app-export-list',
  templateUrl: './export-list.component.html'
})
export class ExportListComponent {

  exportList: Array<ExportModel>
  searchModel: ExportModel = new ExportModel;
  result: string;
  total: number;
  constructor(public dialog: MatDialog, private router: Router, private exportService: ExportService, private confirmationDialogService: ConfirmationDialogService) {

  }

  ngOnInit() {
    this.getAllExport();
  }


  getAllExport() {
    debugger;
    this.exportService.getAll(this.searchModel).subscribe(response => {
      this.exportList = response.List;
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
      this.exportService.delete(id)
        .subscribe((data) => {
          this.getAllExport();
        })
        , error => {

        }
    }
  }

  changePagination(data) {
    this.searchModel.RecordPerPage = data.RecordPerPage;
    this.searchModel.Page = data.CurrentPage;
    this.getAllExport();
  }
}
