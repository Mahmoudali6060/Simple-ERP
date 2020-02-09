import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { DriverService } from '../../services/driver.service';
import { DriverModel } from '../../models/driver.model';
import { ModalBasicComponent } from '../../../../../shared/components/modal-basic/modal-basic.component';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
// import { DriverFormComponent } from '../driver-form/driver-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-driver-list',
  templateUrl: './driver-list.component.html'
})

export class DriverListComponent {
  //#region Variables
  farmList: Array<DriverModel>;//Data List
  properties = ["OwnerName", "OwnerMobile", "Address", "Notes"];//Displayed Columns 
  driver: DriverModel = new DriverModel();//For Add/Update Driver Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private farmService: DriverService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllDrivers();
  }

  //#region GetAll
  getAllDrivers() {
    this.farmService.getAll(this.dataSourceModel).subscribe(response => {
      this.farmList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.farmService.delete(id)
      .subscribe((response) => {
        this.getAllDrivers();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  // public openModal(id?: number) {
  //   const dialogRef = this.dialog.open(DriverFormComponent, {
  //     width: '900px',
  //     // height: '400px',
  //     data: { id: id }
  //   });
  //   dialogRef.afterClosed().subscribe(result => {
  //     if (result) {
  //       this.getAllDrivers();
  //     }
  //   });
  // }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllDrivers();
  }
  //#endregion
}