import { Component, OnInit, Inject, Input, EventEmitter, Output, ViewChild } from '@angular/core';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { ModalBasicComponent } from '../modal-basic/modal-basic.component';
import { DataSourceModel } from '../../../shared/models/data-source.model';

@Component({
  selector: 'app-data-list',
  templateUrl: './data-list.component.html',
  styleUrls: ['./data-list.component.css']
})

export class DataListComponent {
  //#region  Description:
  /*
 [M.Salman]
  this is a generic component for listing data
  */
  //#endregion
  //#region [M.Salman] -[30/1/2020] - [Variables]
  @Input() list;//List(table content)
  @Input() properties;//Table Header
  @Output() deleteRow = new EventEmitter<number>();//When you delete row this will send selected (Id) for parent component
  @Output() editRow = new EventEmitter<number>();//When you edit row this will send selected (Id) for parent component
  @Output() changePagination = new EventEmitter<DataSourceModel>();//When you edit row this will send selected (Id) for parent component
  @ViewChild(ConfirmationDialogComponent, { static: false }) confirmationDialogComponent;//This open dialog for confirmation delete
  @Input() total: number;
  dataSourceModel = new DataSourceModel();
  model: any = {};
  //#endregion

  constructor() {
   
  }

  ngOnInit() {
  }

  showConfirmDialog(id): void {
    this.confirmationDialogComponent.open(id);//Open dialog when you press in delete button
  }

  public delete(id) {
    this.deleteRow.emit(id);//Send selected id to parent after confirmation delete
  }

  public edit(id) {
    this.editRow.emit(id);//Send selected id to parent after editing the entity
  }

  onChangePagination(data) {
    this.dataSourceModel.PageSize = data.RecordPerPage;
    this.dataSourceModel.Page = data.CurrentPage;
    this.changePagination.emit(this.dataSourceModel);
  }

  public applyFilter() {
    this.dataSourceModel.Filter = [];
    for (let property of this.properties) {
      if (this.model[property]) {
        var filter = {
          Key: this.titleCaseWord(property),
          value: this.model[property]
        };
        this.dataSourceModel.Filter.push(filter);
      }

    }
    this.changePagination.emit(this.dataSourceModel);
  }

  public titleCaseWord(word: string) {
    if (!word) return word;
    return word[0].toUpperCase() + word.substr(1);
  }

}


