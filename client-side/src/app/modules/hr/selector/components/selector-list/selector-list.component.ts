import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { SelectorService } from '../../services/selector.service';
import { SelectorModel } from '../../models/selector.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
// import { SelectorFormComponent } from '../selector-form/selector-form.component';
import { MatDialog } from '@angular/material';
import { SelectorFormComponent } from '../selector-form/selector-form.component';
import { ActionModel } from 'src/app/shared/models/action.model';
import { ActionNameEnum } from 'src/app/shared/enums/Action.enum';
import { HelperService } from 'src/app/shared/services/helper.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-selector-list',
  templateUrl: './selector-list.component.html'
})

export class SelectorListComponent {
  //#region Variables
  selectorList: Array<SelectorModel>;//Data List
  properties = ["HeadName", "LastTonPrice", "Balance"];//Displayed Columns 
  selector: SelectorModel = new SelectorModel();//For Add/Update Selector Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  actions: Array<ActionModel>=[];
  //#endregion

  constructor(private selectorService: SelectorService, private dialog: MatDialog, private helperService: HelperService, private router: Router) {
  }

  ngOnInit() {
    this.getAllSelectors();
    this.actions.push(this.helperService.addAction(ActionNameEnum.Details, 'fa fa-list'));
  }

  //#region GetAll
  getAllSelectors() {
    this.selectorService.getAll(this.dataSourceModel).subscribe(response => {
      this.selectorList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }
  //#endregion 

  //#region Deleteing
  public delete(id: number) {
    this.selectorService.delete(id)
      .subscribe((response) => {
        this.getAllSelectors();
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(SelectorFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllSelectors();
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllSelectors();
  }
  //#endregion

  public onMakeAction(event) {
    if (event.action.name == ActionNameEnum.Details) {
      let selectorId = event.id;
      this.router.navigate(['layout/selector/selector-detail-list', selectorId]);
    }
  }


}