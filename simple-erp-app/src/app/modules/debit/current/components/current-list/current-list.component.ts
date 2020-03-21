import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { CurrentService } from '../../services/current.service';
import { CurrentModel } from '../../models/current.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { CurrentFormComponent } from '../current-form/current-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-current-list',
  templateUrl: './current-list.component.html'
})

export class CurrentListComponent {
  //#region Variables
  currentList: Array<CurrentModel>;//Data List
  properties = ["PayDate","Pay","WithdrawsDate","Withdraws","Balance"];//Displayed Columns 
  current: CurrentModel = new CurrentModel();//For Add/Update Current Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private currentService: CurrentService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllCurrents();
  }

  //#region GetAll
  getAllCurrents() {
    this.currentService.getAll(this.dataSourceModel).subscribe(response => {
      this.currentList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.currentService.delete(id)
      .subscribe((response) => {
        this.getAllCurrents();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(CurrentFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllCurrents();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllCurrents();
  }
  //#endregion
}