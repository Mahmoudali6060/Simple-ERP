import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { SelectorDetailService } from '../../services/selector-detail.service';
import { SelectorDetailModel } from '../../models/selector-detail.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { SelectorAccountService } from '../../services/selector-account.service';

@Component({
  selector: 'app-selector-detail-list',
  templateUrl: './selector-detail-list.component.html'
})

export class SelectorDetailListComponent {
  //#region Variables
  selectorDetailList: Array<SelectorDetailModel>;//Data List
  properties = ["PayDate", "Pay", "WithdrawsDate", "Withdraws", "Balance"];//Displayed Columns 
  selectorAccountProperties = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  selectorAccountList: any = [];//Data List
  selectorDetail: SelectorDetailModel = new SelectorDetailModel();//For Add/Update SelectorDetail Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  selectorAccountTotal: number;
  selectorId: number;
  balanceTotal: number;
  paidUpTotal: number;
  //#endregion

  constructor(private selectorDetailService: SelectorDetailService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private selectorAccountService: SelectorAccountService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["selectorId"]) {
      this.selectorId = Number(this.activatedRoute.snapshot.params["selectorId"]);
      this.getAllSelectorDetails();
      this.getAllSelectorAccount();

    }
  }

  //#region GetAll
  getAllSelectorDetails() {
    if (this.selectorId) {
      this.selectorDetailService.getAllBySelectorId(this.selectorId, this.dataSourceModel).subscribe(response => {
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
  getAllSelectorAccount() {
    this.selectorAccountService.getSelectorAccountsBySelectorId(this.selectorId, this.dataSourceModel).subscribe(response => {
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
        this.getAllSelectorDetails();
      })
      , error => {
      }
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllSelectorDetails();
  }
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllSelectorAccount();
  }

  //#endregion
}