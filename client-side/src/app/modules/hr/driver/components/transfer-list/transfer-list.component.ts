import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { TransferService } from '../../services/transfer.service';
import { TransferModel } from '../../models/transfer.model';
import { ModalBasicComponent } from '../../../../../shared/components/modal-basic/modal-basic.component';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
// import { TransferFormComponent } from '../transfer-form/transfer-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-transfer-list',
  templateUrl: './transfer-list.component.html'
})

export class TransferListComponent {
  //#region Variables
  transferList: Array<TransferModel>;//Data List
  properties = ["Date", "FarmName", "StationName", "Nawlon", "Custody", "Withdraws", "Balance", "Notes"];//Displayed Columns 
  transfer: TransferModel = new TransferModel();//For Add/Update Transfer Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private transferService: TransferService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllTransfers();
  }

  //#region GetAll
  getAllTransfers() {
    this.transferService.getAll(this.dataSourceModel).subscribe(response => {
      this.transferList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.transferService.delete(id)
      .subscribe((response) => {
        this.getAllTransfers();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  // public openModal(id?: number) {
  //   const dialogRef = this.dialog.open(TransferFormComponent, {
  //     width: '900px',
  //     // height: '400px',
  //     data: { id: id }
  //   });
  //   dialogRef.afterClosed().subscribe(result => {
  //     if (result) {
  //       this.getAllTransfers();
  //     }
  //   });
  // }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllTransfers();
  }
  //#endregion
}