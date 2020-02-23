import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { IncomeService } from '../../services/income.service';
import { IncomeModel } from '../../models/income.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { IncomeFormComponent } from '../income-form/income-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-income-list',
  templateUrl: './income-list.component.html'
})

export class IncomeListComponent {
  //#region Variables
  incomeList: Array<IncomeModel>;//Data List
  properties = ["Date", "CartNumber", "CategoryName", "FarmName","CarPlate","Quantity","KiloDiscount","QuantityAfterDiscount","KiloPrice","Total","MoneyDiscount","Balance","StationName"];//Displayed Columns 
  safeProperties = ["PaidUp","PaidDate","RecieptNumber"];//Displayed Columns 
  income: IncomeModel = new IncomeModel();//For Add/Update Income Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private incomeService: IncomeService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllIncomes();
  }

  //#region GetAll
  getAllIncomes() {
    this.incomeService.getAll(this.dataSourceModel).subscribe(response => {
      this.incomeList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

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
  //#endregion
}