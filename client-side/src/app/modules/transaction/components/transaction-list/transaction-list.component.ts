import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TransactionService } from '../../services/transaction.service';
import { TransactionModel } from '../../models/transaction.model';
import { ConfirmationDialogComponent } from '../../../../shared/components/confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html'
})
export class TransactionListComponent {

  transactionList: Array<TransactionModel>
  transaction: TransactionModel = new TransactionModel;
  columns = ['Number', 'DateStr', 'FarmOwnerName', 'CategoryName', 'CarPlate', 'SupplierQuantity',
    'Pardon', 'TotalAfterPardon', 'SupplierPrice', 'SupplierAmount', 'Nolon', 'ReaperHead',
    'ReapersPay', 'SelectorsPay', 'FarmExpense', 'SupplierTotal', 'StationOwnerName', 'CartNumber',
    'ClientQuantity', 'ClientDiscount', 'TotalAfterDiscount', 'ClientPrice', 'ClientTotal', 'Sum',];
  searchModel: TransactionModel = new TransactionModel;
  result: string;
  total: number;
  constructor(private datePipe: DatePipe, public dialog: MatDialog, private router: Router, private transactionService: TransactionService) {

  }

  ngOnInit() {
    this.getAllTransaction();
  }

  getAllTransaction() {
    this.transactionService.getAll(this.searchModel).subscribe(response => {
      this.transactionList = this.prepareTransactionList(response.List);
      this.total = response.Total;
    }, err => {

    });
  }

  private prepareTransactionList(transactionList: Array<TransactionModel>) {
    for (let item of transactionList) {
      item.Number = item.Id.toString();
      item.DateStr = this.datePipe.transform(new Date(item.Date), "dd/MM/yyyy");
      ///Supplier Calculations
      item.TotalAfterPardon = item.SupplierQuantity - item.Pardon;
      item.SupplierAmount = item.TotalAfterPardon * item.SupplierPrice;
      item.SupplierTotal = item.SupplierAmount + item.Nolon + item.ReapersPay + item.SelectorsPay + item.FarmExpense;

      ///Client Caluclations
      item.TotalAfterDiscount = item.ClientQuantity - item.ClientDiscount;
      item.ClientTotal = item.TotalAfterDiscount * item.ClientPrice;
      item.Sum = item.ClientTotal - item.SupplierTotal;
    }
    return transactionList;
  }
  showConfirmDialog(id): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent)//, {
    dialogRef.afterClosed().subscribe(dialogResult => {
      this.delete(dialogResult, id);
    });
  }

  private delete(confirmed: boolean, id: number) {
    if (confirmed) {
      this.transactionService.delete(id)
        .subscribe((data) => {
          this.getAllTransaction();
        })
        , error => {
        }
    }
  }

  changePagination(data) {
    this.searchModel.RecordPerPage = data.recordPerPage;
    this.searchModel.Page = data.currentPage;
    this.getAllTransaction();
  }

}
