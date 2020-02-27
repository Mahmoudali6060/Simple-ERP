import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { OutcomeService } from '../../services/outcome.service';
import { OutcomeModel } from '../../models/outcome.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { OutcomeFormComponent } from '../outcome-form/outcome-form.component';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { StationAccountService } from '../../services/station-account.service';

@Component({
  selector: 'app-outcome-list',
  templateUrl: './outcome-list.component.html'
})

export class OutcomeListComponent {
  //#region Variables
  outcomeList: Array<OutcomeModel>;//Data List
  properties = ["Date", "CartNumber", "CategoryName", "StationName", "CarPlate", "Quantity", "KiloDiscount", "QuantityAfterDiscount", "KiloPrice", "Total", "MoneyDiscount", "Balance", "StationName"];//Displayed Columns 
  stationAccountProperties = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  stationAccountList: any = [];//Data List
  outcome: OutcomeModel = new OutcomeModel();//For Add/Update Outcome Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  stationAccountTotal: number;
  stationId: number;
  balanceTotal: number;
  paidUpTotal: number;
  //#endregion

  constructor(private outcomeService: OutcomeService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private stationAccountService: StationAccountService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["stationId"]) {
      this.stationId = Number(this.activatedRoute.snapshot.params["stationId"]);
      this.getAllOutcomes();
      this.getAllStationAccount();

    }
  }

  //#region GetAll
  getAllOutcomes() {
    if (this.stationId) {
      this.outcomeService.getOutcomesByStationId(this.stationId, this.dataSourceModel).subscribe(response => {
        this.outcomeList = response.Data;
        this.total = response.Total;
        this.balanceTotal = response.Entity.BalanceTotal;
      }, err => {
      });
    }
    else {
      this.outcomeService.getAll(this.dataSourceModel).subscribe(response => {
        this.outcomeList = response.Data;
        this.total = response.Total;
      }, err => {
      });
    }

  }
  //#endregion 
  getAllStationAccount() {
    this.stationAccountService.getStationAccountsByStationId(this.stationId, this.dataSourceModel).subscribe(response => {
      this.stationAccountList = response.Data;
      this.stationAccountTotal = response.Total;
      this.paidUpTotal = response.Entity.PaidUpTotal;
    }, err => {
    });
  }
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
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllStationAccount();
  }

  //#endregion
}