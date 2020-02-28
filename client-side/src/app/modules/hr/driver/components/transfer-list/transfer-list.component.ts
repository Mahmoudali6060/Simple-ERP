import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { TransferService } from '../../services/transfer.service';
import { TransferModel } from '../../models/transfer.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { DriverAccountService } from '../../services/driver-account.service';

@Component({
  selector: 'app-transfer-list',
  templateUrl: './transfer-list.component.html'
})

export class TransferListComponent {
  //#region Variables
  transferList: Array<TransferModel>;//Data List
  properties = ["Date", "DriverFullName", "DriverMobile", "CarPlate", "FarmName", "StationName", "Nolon", "Custody", "Withdraws", "Balance", "Notes"];//Displayed Columns 
  driverAccountProperties = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  driverAccountList: any = [];//Data List
  transfer: TransferModel = new TransferModel();//For Add/Update Transfer Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  driverAccountTotal: number;
  driverId: number;
  balanceTotal: number;
  paidUpTotal: number;
  //#endregion

  constructor(private transferService: TransferService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private driverAccountService: DriverAccountService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["driverId"]) {
      this.driverId = Number(this.activatedRoute.snapshot.params["driverId"]);
      this.getAllTransfers();
      this.getAllDriverAccount();

    }
  }

  //#region GetAll
  getAllTransfers() {
    if (this.driverId) {
      this.transferService.getAllByDriverId(this.driverId, this.dataSourceModel).subscribe(response => {
        this.transferList = response.Data;
        this.total = response.Total;
        this.balanceTotal = response.Entity.BalanceTotal;
      }, err => {
      });
    }
    else {
      this.transferService.getAll(this.dataSourceModel).subscribe(response => {
        this.transferList = response.Data;
        this.total = response.Total;
      }, err => {
      });
    }

  }
  //#endregion 
  getAllDriverAccount() {
    this.driverAccountService.getDriverAccountsByDriverId(this.driverId, this.dataSourceModel).subscribe(response => {
      this.driverAccountList = response.Data;
      this.driverAccountTotal = response.Total;
      this.paidUpTotal = response.Entity.PaidUpTotal;
    }, err => {
    });
  }
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

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllTransfers();
  }
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllDriverAccount();
  }

  //#endregion
}