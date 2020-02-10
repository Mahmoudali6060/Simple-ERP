import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { StationService } from '../../services/station.service';
import { StationModel } from '../../models/station.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { StationFormComponent } from '../station-form/station-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-station-list',
  templateUrl: './station-list.component.html'
})

export class StationListComponent {
  //#region Variables
  stationList: Array<StationModel>;//Data List
  properties = ["OwnerName", "OwnerMobile", "Address", "Notes"];//Displayed Columns 
  station: StationModel = new StationModel();//For Add/Update Station Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private stationService: StationService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllStations();
  }

  //#region GetAll
  getAllStations() {
    this.stationService.getAll(this.dataSourceModel).subscribe(response => {
      this.stationList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.stationService.delete(id)
      .subscribe((response) => {
        this.getAllStations();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(StationFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllStations();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllStations();
  }
  //#endregion
}