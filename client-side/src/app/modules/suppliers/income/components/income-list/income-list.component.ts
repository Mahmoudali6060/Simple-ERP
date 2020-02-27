import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { IncomeService } from '../../services/income.service';
import { IncomeModel } from '../../models/income.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { IncomeFormComponent } from '../income-form/income-form.component';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { FarmAccountService } from 'src/app/modules/suppliers/income/services/farm-account.service';

@Component({
  selector: 'app-income-list',
  templateUrl: './income-list.component.html'
})

export class IncomeListComponent {
  //#region Variables
  incomeList: Array<IncomeModel>;//Data List
  properties = ["Date", "CartNumber", "CategoryName", "FarmName", "CarPlate", "Quantity", "KiloDiscount", "QuantityAfterDiscount", "KiloPrice", "Total", "MoneyDiscount", "Balance", "StationName"];//Displayed Columns 
  farmAccountProperties = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  farmAccountList: any = [];//Data List
  income: IncomeModel = new IncomeModel();//For Add/Update Income Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  farmAccountTotal: number;
  farmId: number;
  balanceTotal: number;
  paidUpTotal: number;
  //#endregion

  constructor(private incomeService: IncomeService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private farmAccountService: FarmAccountService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["farmId"]) {
      this.farmId = Number(this.activatedRoute.snapshot.params["farmId"]);
      this.getAllIncomes();
      this.getAllFarmAccount();

    }
  }

  //#region GetAll
  getAllIncomes() {
    if (this.farmId) {
      this.incomeService.getIncomesByFarmId(this.farmId, this.dataSourceModel).subscribe(response => {
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
  getAllFarmAccount() {
    this.farmAccountService.getFarmAccountsByFarmId(this.farmId, this.dataSourceModel).subscribe(response => {
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
        this.getAllIncomes();
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
        this.getAllIncomes();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllIncomes();
  }
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllFarmAccount();
  }
  
  //#endregion
}