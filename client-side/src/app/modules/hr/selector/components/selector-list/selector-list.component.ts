import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { SelectorService } from '../../services/selector.service';
import { SelectorModel } from '../../models/selector.model';
import { ModalBasicComponent } from '../../../../../shared/components/modal-basic/modal-basic.component';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
// import { SelectorFormComponent } from '../selector-form/selector-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-selector-list',
  templateUrl: './selector-list.component.html'
})

export class SelectorListComponent {
  //#region Variables
  farmList: Array<SelectorModel>;//Data List
  properties = ["PayDate", "Pay", "WithdrawsDate", "Withdraws", "Balance"];//Displayed Columns 
  selector: SelectorModel = new SelectorModel();//For Add/Update Selector Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private farmService: SelectorService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllSelectors();
  }

  //#region GetAll
  getAllSelectors() {
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
        this.getAllSelectors();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  // public openModal(id?: number) {
  //   const dialogRef = this.dialog.open(SelectorFormComponent, {
  //     width: '900px',
  //     // height: '400px',
  //     data: { id: id }
  //   });
  //   dialogRef.afterClosed().subscribe(result => {
  //     if (result) {
  //       this.getAllSelectors();
  //     }
  //   });
  // }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllSelectors();
  }
  //#endregion
}