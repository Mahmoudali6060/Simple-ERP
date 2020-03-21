import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { TransferService } from '../../services/transfer.service';
import { TransferModel } from '../../models/transfer.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { DriverAccountService } from '../../services/driver-account.service';
import { DatePipe } from '@angular/common';
import { ReportService } from 'src/app/modules/report/services/report.service';

@Component({
  selector: 'app-transfer-list',
  templateUrl: './transfer-list.component.html'
})

export class TransferListComponent {
  //#region Variables
  transferList: Array<TransferModel>;//Data List
  properties = ["Date", "DriverFullName", "DriverMobile", "CarPlate", "FarmName", "StationName", "Nolon", ];//Displayed Columns 
  driverAccountProperties: any = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  driverAccountList: any = [];//Data List
  transfer: TransferModel = new TransferModel();//For Add/Update Transfer Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  driverAccountTotal: number;
  driverId: number;
  balanceTotal: number;
  paidUpTotal: number;
  reportData: any = [];
  //#endregion

  constructor(private transferService: TransferService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private driverAccountService: DriverAccountService,
    private datePipe: DatePipe,
    private reportService: ReportService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["driverId"]) {
      this.driverId = Number(this.activatedRoute.snapshot.params["driverId"]);
      this.getAllTransfers(this.dataSourceModel);
      this.getAllDriverAccount(this.dataSourceModel);
    }

  }

  //#region GetAll
  getAllTransfers(dataSourceModel: any) {
    if (this.driverId) {
      this.transferService.getAllByDriverId(this.driverId, dataSourceModel).subscribe(response => {
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
  getAllDriverAccount(dataSourceModel: any) {
    this.driverAccountService.getDriverAccountsByDriverId(this.driverId, dataSourceModel).subscribe(response => {
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
        this.getAllTransfers(this.dataSourceModel);
      })
      , error => {
      }
  }
  
  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllTransfers(this.dataSourceModel);
  }
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllDriverAccount(this.dataSourceModel);
  }

  //#endregion

  //#region  Printing
  print(): void {
    this.reportData = [];
    let dataSourceModel = new DataSourceModel();
    dataSourceModel.PageSize = 1000000000;
    this.getAllTransferList(dataSourceModel);

  }

  private getAlldriverAccountList(dataSourceModel) {
    this.driverAccountService.getDriverAccountsByDriverId(this.driverId, dataSourceModel).subscribe(response => {
      let data = {
        list: response.Data,
        title: "المدفوعات",
        headers: ["تاريخ الدفع", "المدفوع", "رقم الوصل"],
        properties: ["PaidDate", "PaidUp", "RecieptNumber"]
      }
      this.reportData.push(data);
      this.reportService.generateReport("كشف حساب سائق",this.reportData,this.paidUpTotal,this.balanceTotal);

    }, err => {
    });
  }
  getAllTransferList(dataSourceModel) {
    this.transferService.getAllByDriverId(this.driverId, dataSourceModel).subscribe(response => {
      let data = {
        list: response.Data,
        title: "الواردات",
        headers: ["التاريخ", "اسم السائق", "رقم الهاتف", "سيارة", "مزرعة", "محطة", "نولون"],
        properties : ["Date", "DriverFullName", "DriverMobile", "CarPlate", "FarmName", "StationName", "Nolon"]//Displayed Columns 
      }
      this.reportData.push(data);
      this.getAlldriverAccountList(dataSourceModel);

    }, err => {
    });
  }


}