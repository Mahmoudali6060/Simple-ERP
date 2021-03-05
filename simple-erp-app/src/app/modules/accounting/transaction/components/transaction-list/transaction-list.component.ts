import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TransactionService } from '../../services/transaction.service';
import { TransactionModel } from '../../models/transaction.model';
import { ConfirmationDialogComponent } from '../../../../../shared/components/confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material';
import { DatePipe } from '@angular/common';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html'
})
export class TransactionListComponent {

  transactionList: Array<TransactionModel>
  transaction: TransactionModel = new TransactionModel;
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  properties = ["Number", "Date", "FarmOwnerName", "CategoryName", "CarPlate", "SupplierQuantity", "Pardon", "TotalAfterPardon",
    "SupplierPrice", "SupplierAmount", "Nolon", "ReapersPay", "StationOwnerName", "SelectorsPay", "FarmExpense",
    "SupplierTotal", "CartNumber", "ClientQuantity", "ClientDiscount", "TotalAfterDiscount", "ClientPrice", "ClientTotal", "Sum"];
  total: number;
  constructor(private datePipe: DatePipe, public dialog: MatDialog, private router: Router, private transactionService: TransactionService) {

  }

  ngOnInit() {
    this.getAllTransaction();
  }

  getAllTransaction() {
    this.transactionService.getAll(this.dataSourceModel).subscribe(response => {
      this.transactionList = response.Data
      this.total = response.Total;
    }, err => {

    });
  }


  public delete(id: number) {
    this.transactionService.delete(id)
      .subscribe((data) => {
        this.getAllTransaction();
      })
      , error => {
      }
  }

  public onSave(item: any) {
    let exsitedItem = this.setUpdatedTransaction(item)
    this.transactionService.save(exsitedItem)
      .subscribe((data) => {
        // this.getAllTransaction();
      })
      , error => {
      }
  }
  
  setUpdatedTransaction(item: any) {
    let exsitedItem = this.transactionList.find(x => x.Id == item.Id);
    exsitedItem.SupplierPrice = parseFloat(item.SupplierPrice);
    exsitedItem.ClientPrice = parseFloat(item.ClientPrice);
    exsitedItem.SupplierAmount = parseFloat(item.SupplierAmount);
    exsitedItem.SupplierTotal = parseFloat(item.SupplierTotal);
    exsitedItem.ClientTotal = parseFloat(item.ClientTotal);
    exsitedItem.Sum = parseFloat(item.Sum);
    return exsitedItem;
  }

  public onEdit(id: number) {
    this.router.navigate(["/layout/transaction/transaction-form", id]);
  }

  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllTransaction();
  }

}
