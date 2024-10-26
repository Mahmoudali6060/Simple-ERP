import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { SafeService } from '../../services/safe.service';
import { SafeModel } from '../../models/safe.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { SafeFormComponent } from '../safe-form/safe-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-safe-list',
  templateUrl: './safe-list.component.html'
})

export class SafeListComponent {
  //#region Variables
  safeList: Array<SafeModel>;//Data List
  properties = ["Date", "Incoming", "Outcoming", "AccountNameAr","Description"];//Displayed Columns 
  safe: SafeModel = new SafeModel();//For Add/Update Safe Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  incomingTotal: number;
  outcomingTotal: number;
  //#endregion

  constructor(private safeService: SafeService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllSafes();
  }

  //#region GetAll
  getAllSafes() {
    this.safeService.getAll(this.dataSourceModel).subscribe(response => {
      this.safeList = response.Data;
      this.total = response.Total;
      this.incomingTotal = response.Entity.IncomingTotal;
      this.outcomingTotal = response.Entity.OutcomingTotal;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.safeService.delete(id)
      .subscribe((response) => {
        this.getAllSafes();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(SafeFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllSafes();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllSafes();
  }
  //#endregion
}