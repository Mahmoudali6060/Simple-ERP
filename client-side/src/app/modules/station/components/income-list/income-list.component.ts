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


@Component({
  selector: 'app-income-list',
  templateUrl: './income-list.component.html'
})
export class IncomeListComponent {

  incomeList: Array<IncomeModel>
  searchModel: IncomeModel = new IncomeModel;
  result: string;
  total: number;
  constructor(public dialog: MatDialog, private router: Router, private incomeService: IncomeService) {

  }

  ngOnInit() {
    this.getAllIncome();
  }


  getAllIncome() {
    debugger;
    this.incomeService.getAll(this.searchModel).subscribe(response => {
      this.incomeList = response.List;
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
      this.incomeService.delete(id)
        .subscribe((data) => {
          this.getAllIncome();
        })
        , error => {

        }
    }
  }

  changePagination(data) {
    this.searchModel.RecordPerPage = data.recordPerPage;
    this.searchModel.Page = data.currentPage;
    this.getAllIncome();
  }
}
