import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { SalaryService } from '../../services/salary.service';
import { SalaryModel } from '../../models/salary.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { SalaryFormComponent } from '../salary-form/salary-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-salary-list',
  templateUrl: './salary-list.component.html'
})

export class SalaryListComponent {
  //#region Variables
  salaryList: Array<SalaryModel>;//Data List
  properties = ["PayDate","Pay","WithdrawsDate","Withdraws","Balance"];//Displayed Columns 
  salary: SalaryModel = new SalaryModel();//For Add/Update Salary Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private salaryService: SalaryService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllSalarys();
  }

  //#region GetAll
  getAllSalarys() {
    this.salaryService.getAll(this.dataSourceModel).subscribe(response => {
      this.salaryList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.salaryService.delete(id)
      .subscribe((response) => {
        this.getAllSalarys();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(SalaryFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllSalarys();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllSalarys();
  }
  //#endregion
}