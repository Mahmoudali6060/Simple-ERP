import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { FarmService } from '../../services/farm.service';
import { FarmModel } from '../../models/farm.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { FarmFormComponent } from '../farm-form/farm-form.component';
import { MatDialog } from '@angular/material';
import { ActionNameEnum } from 'src/app/shared/enums/Action.enum';
import { Router } from '@angular/router';
import { ActionModel } from 'src/app/shared/models/action.model';
import { HelperService } from 'src/app/shared/services/helper.service';

@Component({
  selector: 'app-farm-list',
  templateUrl: './farm-list.component.html'
})

export class FarmListComponent {
  //#region Variables
  farmList: Array<FarmModel>;//Data List
  properties = ["OwnerName", "OwnerMobile", "Address", "Notes"];//Displayed Columns 
  farm: FarmModel = new FarmModel();//For Add/Update Farm Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  actions: Array<ActionModel> = [];

  //#endregion

  constructor(private farmService: FarmService,
    private dialog: MatDialog,
    private router: Router,
    private helperService: HelperService) {
  }

  ngOnInit() {
    this.getAllFarms();
    this.actions.push(this.helperService.addAction(ActionNameEnum.Details, 'fa fa-list'));
  }

  //#region GetAll
  getAllFarms() {
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
        this.getAllFarms();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(FarmFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllFarms();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllFarms();
  }
  //#endregion
  public onMakeAction(event) {
    if (event.action.name == ActionNameEnum.Details) {
      this.router.navigate(['layout/income/income-list', event.id]);
    }
  }
}