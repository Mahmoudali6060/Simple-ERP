import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { SelectorDetailService } from '../../services/selector-detail.service';
import { SelectorDetailModel } from '../../models/selector-detail.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { SelectorAccountService } from '../../services/selector-account.service';
import { DatePipe } from '@angular/common';
import { ReportService } from 'src/app/modules/report/services/report.service';

@Component({
  selector: 'app-selector-detail-list',
  templateUrl: './selector-detail-list.component.html'
})

export class SelectorDetailListComponent {
  //#region Variables
  selectorDetailList: Array<SelectorDetailModel>;//Data List
  properties = ["Date","HeadName", "Weight", "TonPrice"];//Displayed Columns 
  selectorAccountProperties: any = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  selectorAccountList: any = [];//Data List
  selectorDetail: SelectorDetailModel = new SelectorDetailModel();//For Add/Update SelectorDetail Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  selectorAccountTotal: number;
  selectorId: number;
  balanceTotal: number;
  paidUpTotal: number;
  reportData: any = [];
  //#endregion

  constructor(private selectorDetailService: SelectorDetailService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private selectorAccountService: SelectorAccountService,
    private datePipe: DatePipe,
    private reportService: ReportService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["selectorId"]) {
      this.selectorId = Number(this.activatedRoute.snapshot.params["selectorId"]);
      this.getAllSelectorDetails(this.dataSourceModel);
      this.getAllSelectorAccount(this.dataSourceModel);
    }

  }

  //#region GetAll
  getAllSelectorDetails(dataSourceModel: any) {
    if (this.selectorId) {
      this.selectorDetailService.getAllBySelectorId(this.selectorId, dataSourceModel).subscribe(response => {
        this.selectorDetailList = response.Data;
        this.total = response.Total;
        this.balanceTotal = response.Entity.BalanceTotal;
      }, err => {
      });
    }
    else {
      this.selectorDetailService.getAll(this.dataSourceModel).subscribe(response => {
        this.selectorDetailList = response.Data;
        this.total = response.Total;
      }, err => {
      });
    }

  }
  //#endregion 
  getAllSelectorAccount(dataSourceModel: any) {
    this.selectorAccountService.getSelectorAccountsBySelectorId(this.selectorId, dataSourceModel).subscribe(response => {
      this.selectorAccountList = response.Data;
      this.selectorAccountTotal = response.Total;
      this.paidUpTotal = response.Entity.PaidUpTotal;
    }, err => {
    });
  }
  //#region Deleteing
  public delete(id: number) {
    this.selectorDetailService.delete(id)
      .subscribe((response) => {
        this.getAllSelectorDetails(this.dataSourceModel);
      })
      , error => {
      }
  }

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllSelectorDetails(this.dataSourceModel);
  }
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllSelectorAccount(this.dataSourceModel);
  }

  //#endregion

  //#region  Printing
  print(): void {
    this.reportData = [];
    let dataSourceModel = new DataSourceModel();
    dataSourceModel.PageSize = 1000000000;
    this.getAllSelectorDetailList(dataSourceModel);

  }

  private getAllselectorAccountList(dataSourceModel) {
    this.selectorAccountService.getSelectorAccountsBySelectorId(this.selectorId, dataSourceModel).subscribe(response => {
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
  getAllSelectorDetailList(dataSourceModel) {
    this.selectorDetailService.getAllBySelectorId(this.selectorId, dataSourceModel).subscribe(response => {
      let data = {
        list: response.Data,
        title: "حساب القطف",
        headers: ["التاريخ","ريس القطف", "الوزن", "سعر الطن"],
        properties :["Date", "HeadName","Weight", "TonPrice"]//Displayed Columns 
      }
      this.reportData.push(data);
      this.getAllselectorAccountList(dataSourceModel);

    }, err => {
    });
  }


}