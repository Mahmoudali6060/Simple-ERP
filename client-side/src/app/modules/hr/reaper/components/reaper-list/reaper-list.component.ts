import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { ReaperService } from '../../services/reaper.service';
import { ReaperModel } from '../../models/reaper.model';
import { ModalBasicComponent } from '../../../../../shared/components/modal-basic/modal-basic.component';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
// import { ReaperFormComponent } from '../reaper-form/reaper-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-reaper-list',
  templateUrl: './reaper-list.component.html'
})

export class ReaperListComponent {
  //#region Variables
  reaperList: Array<ReaperModel>;//Data List
  properties = ["OwnerName", "OwnerMobile", "Address", "Notes"];//Displayed Columns 
  reaper: ReaperModel = new ReaperModel();//For Add/Update Reaper Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private reaperService: ReaperService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllReapers();
  }

  //#region GetAll
  getAllReapers() {
    this.reaperService.getAll(this.dataSourceModel).subscribe(response => {
      this.reaperList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.reaperService.delete(id)
      .subscribe((response) => {
        this.getAllReapers();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  // public openModal(id?: number) {
  //   const dialogRef = this.dialog.open(ReaperFormComponent, {
  //     width: '900px',
  //     // height: '400px',
  //     data: { id: id }
  //   });
  //   dialogRef.afterClosed().subscribe(result => {
  //     if (result) {
  //       this.getAllReapers();
  //     }
  //   });
  // }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllReapers();
  }
  //#endregion
}