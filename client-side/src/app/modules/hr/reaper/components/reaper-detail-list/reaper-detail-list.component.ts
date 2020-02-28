import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { ReaperDetailService } from '../../services/reaper-detail.service';
import { ReaperDetailModel } from '../../models/reaper-detail.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { ReaperAccountService } from '../../services/reaper-account.service';

@Component({
  selector: 'app-reaper-detail-list',
  templateUrl: './reaper-detail-list.component.html'
})

export class ReaperDetailListComponent {
  //#region Variables
  reaperDetailList: Array<ReaperDetailModel>;//Data List
  properties = ["Date", "Weight", "TonPrice", "PaidUp", "PaidDate"];//Displayed Columns 
  reaperAccountProperties = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  reaperAccountList: any = [];//Data List
  reaperDetail: ReaperDetailModel = new ReaperDetailModel();//For Add/Update ReaperDetail Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  reaperAccountTotal: number;
  reaperId: number;
  balanceTotal: number;
  paidUpTotal: number;
  //#endregion

  constructor(private reaperDetailService: ReaperDetailService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private reaperAccountService: ReaperAccountService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["reaperId"]) {
      this.reaperId = Number(this.activatedRoute.snapshot.params["reaperId"]);
      this.getAllReaperDetails();
      this.getAllReaperAccount();

    }
  }

  //#region GetAll
  getAllReaperDetails() {
    if (this.reaperId) {
      this.reaperDetailService.getAllByReaperId(this.reaperId, this.dataSourceModel).subscribe(response => {
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
  getAllReaperAccount() {
    this.reaperAccountService.getReaperAccountsByReaperId(this.reaperId, this.dataSourceModel).subscribe(response => {
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
        this.getAllReaperDetails();
      })
      , error => {
      }
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllReaperDetails();
  }
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllReaperAccount();
  }

  //#endregion
}