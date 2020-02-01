
import { Component, OnInit, Inject, Input, EventEmitter, Output, ViewChild } from '@angular/core';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-data-list',
  templateUrl: './data-list.component.html'
  // styleUrls: ['./data-list.component.css']
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
  @Input() entity;//Generate headers from this entity
  @Input() columns;//Table Header
  @Output() deleteRow = new EventEmitter<number>();//When you delete row this will send selected (Id) for parent component
  @Output() editRow = new EventEmitter<number>();//When you edit row this will send selected (Id) for parent component
  // @ViewChild(ConfirmationDialogComponent) confirmationDialogComponent;//This open dialog for confirmation delete
  //#endregion

  constructor() {
  }

  ngOnInit() {
    this.prepareHeaders(this.list);//Prepare header of table 
  }

  private prepareHeaders(data: any) {
    // this.headers = Object.keys(this.entity).filter(x => x != 'Id');//Getting the name of column based on entity properties for displaying them in table header
  }

  showConfirmDialog(id): void {
    // this.confirmationModalComponent.open(id);//Open dialog when you press in delete button
  }

  public delete(id) {
    this.deleteRow.emit(id);//Send selected id to parent after confirmation delete
  }

  public edit(id) {
    this.editRow.emit(id);//Send selected id to parent after editing the entity
  }

}


