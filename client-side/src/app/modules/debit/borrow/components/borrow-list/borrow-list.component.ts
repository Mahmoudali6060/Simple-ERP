import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { BorrowService } from '../../services/borrow.service';
import { BorrowModel } from '../../models/borrow.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { BorrowFormComponent } from '../borrow-form/borrow-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-borrow-list',
  templateUrl: './borrow-list.component.html'
})

export class BorrowListComponent {
  //#region Variables
  borrowList: Array<BorrowModel>;//Data List
  properties = ["PayDate","Pay","WithdrawsDate","Withdraws","Balance"];//Displayed Columns 
  borrow: BorrowModel = new BorrowModel();//For Add/Update Borrow Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private borrowService: BorrowService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllBorrows();
  }

  //#region GetAll
  getAllBorrows() {
    this.borrowService.getAll(this.dataSourceModel).subscribe(response => {
      this.borrowList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.borrowService.delete(id)
      .subscribe((response) => {
        this.getAllBorrows();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(BorrowFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllBorrows();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllBorrows();
  }
  //#endregion
}