import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { SelectorDetailService } from '../../services/selector-detail.service';
import { SelectorDetailModel } from '../../models/selector-detail.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
// import { SelectorDetailFormComponent } from '../selectorDetail-form/selectorDetail-form.component';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-selector-detail-list',
  templateUrl: './selector-detail-list.component.html'
})

export class SelectorDetailListComponent {
  //#region Variables
  selectorDetailList: Array<SelectorDetailModel>;//Data List
  properties = ["PayDate", "Pay", "WithdrawsDate", "Withdraws", "Balance"];//Displayed Columns 
  selectorDetail: SelectorDetailModel = new SelectorDetailModel();//For Add/Update SelectorDetail Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  selectorId: number;
  //#endregion

  constructor(private selectorService: SelectorDetailService, private dialog: MatDialog, private activeRoute: ActivatedRoute) {
  }

  ngOnInit() {
    if (this.activeRoute.snapshot.params["selectorId"]) {
      this.selectorId = Number(this.activeRoute.snapshot.params["selectorId"]);
      this.getAllBySelectorId();
    }
  }

  //#region GetAll
  getAllBySelectorId() {
    this.selectorService.getAllBySelectorId(this.selectorId, this.dataSourceModel).subscribe(response => {
      this.selectorDetailList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.selectorService.delete(id)
      .subscribe((response) => {
        this.getAllBySelectorId();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  // public openModal(id?: number) {
  //   const dialogRef = this.dialog.open(SelectorDetailFormComponent, {
  //     width: '900px',
  //     // height: '400px',
  //     data: { id: id }
  //   });
  //   dialogRef.afterClosed().subscribe(result => {
  //     if (result) {
  //       this.getAllSelectorDetails();
  //     }
  //   });
  // }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllBySelectorId();
  }
  //#endregion
}