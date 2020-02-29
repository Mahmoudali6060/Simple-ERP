import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { ReaperDetailService } from '../../services/reaper-detail.service';
import { ReaperDetailModel } from '../../models/reaper-detail.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { ReaperAccountService } from '../../services/reaper-account.service';
import { DatePipe } from '@angular/common';
import { ReportService } from 'src/app/modules/report/services/report.service';

@Component({
  selector: 'app-reaper-detail-list',
  templateUrl: './reaper-detail-list.component.html'
})

export class ReaperDetailListComponent {
  //#region Variables
  reaperDetailList: Array<ReaperDetailModel>;//Data List
  properties = ["Date","HeadName", "Weight", "TonPrice"];//Displayed Columns 
  reaperAccountProperties: any = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  reaperAccountList: any = [];//Data List
  reaperDetail: ReaperDetailModel = new ReaperDetailModel();//For Add/Update ReaperDetail Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  reaperAccountTotal: number;
  reaperId: number;
  balanceTotal: number;
  paidUpTotal: number;
  reportData: any = [];
  //#endregion

  constructor(private reaperDetailService: ReaperDetailService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private reaperAccountService: ReaperAccountService,
    private datePipe: DatePipe,
    private reportService: ReportService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["reaperId"]) {
      this.reaperId = Number(this.activatedRoute.snapshot.params["reaperId"]);
      this.getAllReaperDetails(this.dataSourceModel);
      this.getAllReaperAccount(this.dataSourceModel);
    }

  }

  //#region GetAll
  getAllReaperDetails(dataSourceModel: any) {
    if (this.reaperId) {
      this.reaperDetailService.getAllByReaperId(this.reaperId, dataSourceModel).subscribe(response => {
        this.reaperDetailList = response.Data;
        this.total = response.Total;
        this.balanceTotal = response.Entity.BalanceTotal;
      }, err => {
      });
    }
    else {
      this.reaperDetailService.getAll(this.dataSourceModel).subscribe(response => {
        this.reaperDetailList = response.Data;
        this.total = response.Total;
      }, err => {
      });
    }

  }
  //#endregion 
  getAllReaperAccount(dataSourceModel: any) {
    this.reaperAccountService.getReaperAccountsByReaperId(this.reaperId, dataSourceModel).subscribe(response => {
      this.reaperAccountList = response.Data;
      this.reaperAccountTotal = response.Total;
      this.paidUpTotal = response.Entity.PaidUpTotal;
    }, err => {
    });
  }
  //#region Deleteing
  public delete(id: number) {
    this.reaperDetailService.delete(id)
      .subscribe((response) => {
        this.getAllReaperDetails(this.dataSourceModel);
      })
      , error => {
      }
  }

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllReaperDetails(this.dataSourceModel);
  }
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllReaperAccount(this.dataSourceModel);
  }

  //#endregion

  //#region  Printing
  print(): void {
    this.reportData = [];
    let dataSourceModel = new DataSourceModel();
    dataSourceModel.PageSize = 1000000000;
    this.getAllReaperDetailList(dataSourceModel);

  }

  private getAllreaperAccountList(dataSourceModel) {
    this.reaperAccountService.getReaperAccountsByReaperId(this.reaperId, dataSourceModel).subscribe(response => {
      let data = {
        list: response.Data,
        title: "المدفوعات",
        headers: ["تاريخ الدفع", "المدفوع", "رقم الوصل"],
        properties: ["PaidDate", "PaidUp", "RecieptNumber"]
      }
      this.reportData.push(data);
      this.reportService.generateReport("كشف حساب القطف", this.reportData, this.paidUpTotal, this.balanceTotal);

    }, err => {
    });
  }
  getAllReaperDetailList(dataSourceModel) {
    this.reaperDetailService.getAllByReaperId(this.reaperId, dataSourceModel).subscribe(response => {
      let data = {
        list: response.Data,
        title: "حساب القطف",
        headers: ["التاريخ","ريس القطف", "الوزن", "سعر الطن"],
        properties :["Date", "HeadName","Weight", "TonPrice"]//Displayed Columns 
      }
      this.reportData.push(data);
      this.getAllreaperAccountList(dataSourceModel);

    }, err => {
    });
  }


}