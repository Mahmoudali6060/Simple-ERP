import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { OutcomeService } from '../../services/outcome.service';
import { OutcomeModel } from '../../models/outcome.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { StationAccountService } from '../../services/station-account.service';
import { DatePipe } from '@angular/common';
import { ReportService } from 'src/app/modules/report/services/report.service';

@Component({
  selector: 'app-outcome-list',
  templateUrl: './outcome-list.component.html'
})

export class OutcomeListComponent {
  //#region Variables
  outcomeList: Array<OutcomeModel>;//Data List
  properties: any = ["Date", "CartNumber", "CategoryName", "StationName", "CarPlate", "Quantity", "KiloDiscount", "QuantityAfterDiscount", "KiloPrice", "Total", "MoneyDiscount", "Balance", "FarmName"];//Displayed Columns 
  stationAccountProperties: any = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  stationAccountList: any = [];//Data List
  outcome: OutcomeModel = new OutcomeModel();//For Add/Update Outcome Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  stationAccountTotal: number;
  stationId: number;
  balanceTotal: number;
  paidUpTotal: number;
  reportData: any = [];
  //#endregion

  constructor(private outcomeService: OutcomeService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private stationAccountService: StationAccountService,
    private datePipe: DatePipe,
    private reportService: ReportService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["stationId"]) {
      this.stationId = Number(this.activatedRoute.snapshot.params["stationId"]);
      this.getAllOutcomes(this.dataSourceModel);
      this.getAllStationAccount(this.dataSourceModel);
    }

  }

  //#region GetAll
  getAllOutcomes(dataSourceModel: any) {
    if (this.stationId) {
      this.outcomeService.getOutcomesByStationId(this.stationId, dataSourceModel).subscribe(response => {
        this.outcomeList = response.Data;
        this.total = response.Total;
        this.balanceTotal = response.Entity.BalanceTotal;
      }, err => {
      });
    }
    else {
      this.outcomeService.getAll(this.dataSourceModel).subscribe(response => {
        this.outcomeList = response.Data;
        this.total = response.Total;
      }, err => {
      });
    }

  }
  //#endregion 
  getAllStationAccount(dataSourceModel: any) {
    this.stationAccountService.getStationAccountsByStationId(this.stationId, dataSourceModel).subscribe(response => {
      this.stationAccountList = response.Data;
      this.stationAccountTotal = response.Total;
      this.paidUpTotal = response.Entity.PaidUpTotal;
    }, err => {
    });
  }
  //#region Deleteing
  public delete(id: number) {
    this.outcomeService.delete(id)
      .subscribe((response) => {
        this.getAllOutcomes(this.dataSourceModel);
      })
      , error => {
      }
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllOutcomes(this.dataSourceModel);
  }
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllStationAccount(this.dataSourceModel);
  }

  //#endregion

  //#region  Printing
  print(): void {
    this.reportData = [];
    let dataSourceModel = new DataSourceModel();
    dataSourceModel.PageSize = 1000000000;
    this.getAllOutcomeList(dataSourceModel);

  }

  private getAllstationAccountList(dataSourceModel) {
    this.stationAccountService.getStationAccountsByStationId(this.stationId, dataSourceModel).subscribe(response => {
      let data = {
        list: response.Data,
        title: "المدفوعات",
        headers: ["تاريخ الدفع", "المدفوع", "رقم الوصل"],
        properties: ["PaidDate", "PaidUp", "RecieptNumber"]
      }
      this.reportData.push(data);
      this.reportService.generateReport("كشف حساب محطة",this.reportData,this.paidUpTotal,this.balanceTotal);

    }, err => {
    });
  }
  getAllOutcomeList(dataSourceModel) {
    this.outcomeService.getOutcomesByStationId(this.stationId, dataSourceModel).subscribe(response => {
      let data = {
        list: response.Data,
        title: "الواردات",
        headers: ["التاريخ", "كارتة", "صنف", "محطة", "سيارة", "كمية", "خصم", "صافي", "سعر", "اجمالي", "خصم", "رصيد", "مزرعة"],
        properties: ["Date", "CartNumber", "CategoryName", "StationName", "CarPlate", "Quantity", "KiloDiscount", "QuantityAfterDiscount", "KiloPrice", "Total", "MoneyDiscount", "Balance", "FarmName"]
      }
      this.reportData.push(data);
      this.getAllstationAccountList(dataSourceModel);

    }, err => {
    });
  }


}