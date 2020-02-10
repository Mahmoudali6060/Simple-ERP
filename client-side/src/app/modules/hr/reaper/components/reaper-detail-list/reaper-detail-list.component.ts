import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { ReaperDetailService } from '../../services/reaper-detail.service';
import { ReaperDetailModel } from '../../models/reaper-detail.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
// import { reaperDetailFormComponent } from '../reaperDetail-form/reaperDetail-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-reaper-detail-list',
  templateUrl: './reaper-detail-list.component.html'
})

export class ReaperDetailListComponent {
  //#region Variables
  reaperDetailList: Array<ReaperDetailModel>;//Data List
  properties = ["Date", "Weight", "TonPrice", "PaidUp", "PaidDate"];//Displayed Columns 
  reaperDetail: ReaperDetailModel = new ReaperDetailModel();//For Add/Update reaperDetail Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private reaperDetailService: ReaperDetailService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllreaperDetails();
  }

  //#region GetAll
  getAllreaperDetails() {
    this.reaperDetailService.getAll(this.dataSourceModel).subscribe(response => {
      this.reaperDetailList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.reaperDetailService.delete(id)
      .subscribe((response) => {
        this.getAllreaperDetails();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  // public openModal(id?: number) {
  //   const dialogRef = this.dialog.open(reaperDetailFormComponent, {
  //     width: '900px',
  //     // height: '400px',
  //     data: { id: id }
  //   });
  //   dialogRef.afterClosed().subscribe(result => {
  //     if (result) {
  //       this.getAllreaperDetails();
  //     }
  //   });
  // }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllreaperDetails();
  }
  //#endregion
}