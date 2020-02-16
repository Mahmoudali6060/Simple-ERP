import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { DriverService } from '../../services/driver.service';
import { DriverModel } from '../../models/driver.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { MatDialog } from '@angular/material';
import { ActionModel } from '../../../../../shared/models/action.model';
import { ActionNameEnum } from '../../../../../shared/enums/Action.enum';
import { Router } from '@angular/router';
import { DriverFormComponent } from 'src/app/modules/hr/driver/components/driver-form/driver-form.component';

@Component({
  selector: 'app-driver-list',
  templateUrl: './driver-list.component.html'
})

export class DriverListComponent {
  //#region Variables
  driverList: Array<DriverModel>;//Data List
  properties = ["FullName", "Mobile", "CarPlate"];//Displayed Columns 
  driver: DriverModel = new DriverModel();//For Add/Update Driver Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  actions: Array<ActionModel>;
  //#endregion

  constructor(private driverService: DriverService, private dialog: MatDialog, private router: Router) {
  }

  ngOnInit() {
    this.getAllDrivers();
    this.prepareActions();
  }

  //#region GetAll
  getAllDrivers() {
    this.driverService.getAll(this.dataSourceModel).subscribe(response => {
      this.driverList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.driverService.delete(id)
      .subscribe((response) => {
        this.getAllDrivers();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(DriverFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllDrivers();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllDrivers();
  }
  //#endregion

  public onMakeAction(event) {
    if (event.action.name == ActionNameEnum.Details) {
      let driverId = event.id;
      this.router.navigate(['layout/driver/transfer-list', driverId]);
    }
  }

  private prepareActions() {
    this.actions = [];
    let action = {
      name: ActionNameEnum.Details,
      icon: "fa fa-list"
    };
    this.actions.push(action);
  }
}