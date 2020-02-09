import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { OutcomeService } from '../../services/outcome.service';
import { OutcomeModel } from '../../models/outcome.model';
import { ModalBasicComponent } from '../../../../../shared/components/modal-basic/modal-basic.component';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { OutcomeFormComponent } from '../outcome-form/outcome-form.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-outcome-list',
  templateUrl: './outcome-list.component.html'
})

export class OutcomeListComponent {
  //#region Variables
  outcomeList: Array<OutcomeModel>;//Data List
  properties = ["Date", "CartNumber", "CategoryName", "FarmName","CarPlate","Quantity","KiloDiscount","Total","KiloPrice","MoneyDiscount","Balance","StationName","PaidUp","PaidDate","RecieptNumber"];//Displayed Columns 
  outcome: OutcomeModel = new OutcomeModel();//For Add/Update Outcome Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  //#endregion

  constructor(private outcomeService: OutcomeService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getAllOutcomes();
  }

  //#region GetAll
  getAllOutcomes() {
    this.outcomeService.getAll(this.dataSourceModel).subscribe(response => {
      this.outcomeList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.outcomeService.delete(id)
      .subscribe((response) => {
        this.getAllOutcomes();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(OutcomeFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllOutcomes();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllOutcomes();
  }
  //#endregion
}