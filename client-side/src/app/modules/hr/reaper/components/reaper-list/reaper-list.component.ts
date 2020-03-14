import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { ReaperService } from '../../services/reaper.service';
import { ReaperModel } from '../../models/reaper.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
// import { ReaperFormComponent } from '../reaper-form/reaper-form.component';
import { MatDialog } from '@angular/material';
import { ReaperFormComponent } from '../reaper-form/reaper-form.component';
import { ActionModel } from 'src/app/shared/models/action.model';
import { ActionNameEnum } from 'src/app/shared/enums/Action.enum';
import { HelperService } from 'src/app/shared/services/helper.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reaper-list',
  templateUrl: './reaper-list.component.html'
})

export class ReaperListComponent {
  //#region Variables
  reaperList: Array<ReaperModel>;//Data List
  properties = ["HeadName", "LastTonPrice"];//Displayed Columns 
  reaper: ReaperModel = new ReaperModel();//For Add/Update Reaper Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  actions: Array<ActionModel> = [];
  //#endregion

  constructor(private reaperService: ReaperService, private dialog: MatDialog, private helperService: HelperService, private router: Router) {
  }

  ngOnInit() {
    this.getAllReapers();
    this.actions.push(this.helperService.addAction(ActionNameEnum.Details, 'fa fa-list'));
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
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(ReaperFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllReapers();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllReapers();
  }
  //#endregion

  public onMakeAction(event) {
    if (event.action.name == ActionNameEnum.Details) {
      let reaperId = event.id;
      this.router.navigate(['layout/reaper/reaper-detail-list', reaperId]);
    }
  }


}