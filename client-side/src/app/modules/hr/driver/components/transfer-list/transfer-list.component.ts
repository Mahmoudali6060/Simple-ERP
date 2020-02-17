import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { TransferService } from '../../services/transfer.service';
import { TransferModel } from '../../models/transfer.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
// import { TransferFormComponent } from '../transfer-form/transfer-form.component';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-transfer-list',
  templateUrl: './transfer-list.component.html'
})

export class TransferListComponent {
  //#region Variables
  transferList: Array<TransferModel>;//Data List
  properties = ["Date", "DriverFullName", "DriverMobile", "CarPlate", "FarmName", "StationName", "Nolon", "Custody", "Withdraws", "Balance", "Notes"];//Displayed Columns 
  transfer: TransferModel = new TransferModel();//For Add/Update Transfer Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  driverId: number;
  //#endregion

  constructor(private transferService: TransferService, private dialog: MatDialog, private activeRoute: ActivatedRoute) {
  }

  ngOnInit() {
    if (this.activeRoute.snapshot.params["driverId"]) {
      this.driverId = Number(this.activeRoute.snapshot.params["driverId"]);
      this.getAllByDriverId(this.driverId);
    }
    else {
      this.getAllTransfers();
    }
  }

  //#region GetAll
  getAllTransfers() {
    // if (this.driverId) {
    //   let filter = {
    //     Key: "DriverId",
    //     Value: this.driverId
    //   };
    //   if (!this.dataSourceModel.Filter)
    //     this.dataSourceModel.Filter = [];
    //   this.dataSourceModel.Filter.push(filter);
    // }

    this.transferService.getAll(this.dataSourceModel).subscribe(response => {
      this.transferList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }

  getAllByDriverId(driverId: number) {
    this.transferService.getAllByDriverId(driverId, this.dataSourceModel).subscribe(response => {
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