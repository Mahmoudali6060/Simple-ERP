import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { IncomeService } from '../../services/income.service';
import { IncomeModel } from '../../models/income.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { IncomeFormComponent } from '../income-form/income-form.component';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { FarmAccountService } from 'src/app/modules/suppliers/income/services/farm-account.service';
import { DatePipe } from '@angular/common';
import { ReportService } from 'src/app/modules/report/services/report.service';

@Component({
  selector: 'app-income-list',
  templateUrl: './income-list.component.html'
})

export class IncomeListComponent {
  //#region Variables
  incomeList: Array<IncomeModel>;//Data List
  properties: any = ["Date", "CartNumber", "CategoryName", "FarmName", "CarPlate", "Quantity", "KiloDiscount", "QuantityAfterDiscount", "KiloPrice", "Total", "MoneyDiscount", "Balance", "StationName"];//Displayed Columns 
  farmAccountProperties: any = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  farmAccountList: any = [];//Data List
  income: IncomeModel = new IncomeModel();//For Add/Update Income Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  farmAccountTotal: number;
  farmId: number;
  balanceTotal: number;
  paidUpTotal: number;
  reportData: any = [];
  //#endregion

  constructor(private incomeService: IncomeService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private farmAccountService: FarmAccountService,
    private datePipe: DatePipe,
    private reportService: ReportService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["farmId"]) {
      this.farmId = Number(this.activatedRoute.snapshot.params["farmId"]);
      this.getAllIncomes(this.dataSourceModel);
      this.getAllFarmAccount(this.dataSourceModel);
    }

  }

  //#region GetAll
  getAllIncomes(dataSourceModel: any) {
    if (this.farmId) {
      this.incomeService.getIncomesByFarmId(this.farmId, dataSourceModel).subscribe(response => {
        this.incomeList = response.Data;
        this.total = response.Total;
        this.balanceTotal = response.Entity.BalanceTotal;
      }, err => {
      });
    }
    else {
      this.incomeService.getAll(this.dataSourceModel).subscribe(response => {
        this.incomeList = response.Data;
        this.total = response.Total;
      }, err => {
      });
    }

  }
  //#endregion 
  getAllFarmAccount(dataSourceModel: any) {
    this.farmAccountService.getFarmAccountsByFarmId(this.farmId, dataSourceModel).subscribe(response => {
      this.farmAccountList = response.Data;
      this.farmAccountTotal = response.Total;
      this.paidUpTotal = response.Entity.PaidUpTotal;
    }, err => {
    });
  }
  //#region Deleteing
  public delete(id: number) {
    this.incomeService.delete(id)
      .subscribe((response) => {
        this.getAllIncomes(this.dataSourceModel);
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(IncomeFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllIncomes(this.dataSourceModel);
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllIncomes(this.dataSourceModel);
  }
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllFarmAccount(this.dataSourceModel);
  }

  //#endregion

  //#region  Printing
  print(): void {
    this.reportData = [];
    let dataSourceModel = new DataSourceModel();
    dataSourceModel.PageSize = 1000000000;
    this.getAllIncomeList(dataSourceModel);

  }

  private getAllfarmAccountList(dataSourceModel) {
    this.farmAccountService.getFarmAccountsByFarmId(this.farmId, dataSourceModel).subscribe(response => {
      let data = {
        list: response.Data,
        title: "المدفوعات",
        headers: ["تاريخ الدفع", "المدفوع", "رقم الوصل"],
        properties: ["PaidDate", "PaidUp", "RecieptNumber"]
      }
      this.reportData.push(data);
      this.reportService.generateReport("كشف حساب مزرعة",this.reportData,this.paidUpTotal,this.balanceTotal);

    }, err => {
    });
  }
  getAllIncomeList(dataSourceModel) {
    this.incomeService.getIncomesByFarmId(this.farmId, dataSourceModel).subscribe(response => {
      let data = {
        list: response.Data,
        title: "الواردات",
        headers: ["التاريخ", "كارتة", "صنف", "مرزعة", "سيارة", "كمية", "خصم", "صافي", "سعر", "اجمالي", "خصم", "رصيد", "محطة"],
        properties: ["Date", "CartNumber", "CategoryName", "FarmName", "CarPlate", "Quantity", "KiloDiscount", "QuantityAfterDiscount", "KiloPrice", "Total", "MoneyDiscount", "Balance", "StationName"]
      }
      this.reportData.push(data);
      this.getAllfarmAccountList(dataSourceModel);

    }, err => {
    });
  }


}