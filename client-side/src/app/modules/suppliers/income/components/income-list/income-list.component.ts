import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { IncomeService } from '../../services/income.service';
import { IncomeModel } from '../../models/income.model';
import { DataSourceModel } from '../../../../../shared/models/data-source.model';
import { IncomeFormComponent } from '../income-form/income-form.component';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { FarmAccountService } from 'src/app/modules/suppliers/income/services/farm-account.service';

@Component({
  selector: 'app-income-list',
  templateUrl: './income-list.component.html'
})

export class IncomeListComponent {
  //#region Variables
  incomeList: Array<IncomeModel>;//Data List
  properties: any = ["Date", "CartNumber", "CategoryName", "FarmName", "CarPlate", "Quantity", "KiloDiscount", "QuantityAfterDiscount", "KiloPrice", "Total", "MoneyDiscount", "Balance", "StationName"];//Displayed Columns 
  farmAccountProperties: any = ["PaidUp", "PaidDate", "RecieptNumber"];//Displayed Columns 
  farmAccountList: any = [];//Data List
  income: IncomeModel = new IncomeModel();//For Add/Update Income Entity
  dataSourceModel: DataSourceModel = new DataSourceModel;//Pagination and Filteration Settings
  total: number;//Total number of rows
  farmAccountTotal: number;
  farmId: number;
  balanceTotal: number;
  paidUpTotal: number;

  //#endregion

  constructor(private incomeService: IncomeService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private farmAccountService: FarmAccountService) {
  }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params["farmId"]) {
      this.farmId = Number(this.activatedRoute.snapshot.params["farmId"]);
      this.getAllIncomes(this.dataSourceModel);
      this.getAllFarmAccount(this.dataSourceModel);

    }
  }

  //#region GetAll
  getAllIncomes(dataSourceModel: any) {
    if (this.farmId) {
      this.incomeService.getIncomesByFarmId(this.farmId, dataSourceModel).subscribe(response => {
        this.incomeList = response.Data;
        this.total = response.Total;
        this.balanceTotal = response.Entity.BalanceTotal;
      }, err => {
      });
    }
    else {
      this.incomeService.getAll(this.dataSourceModel).subscribe(response => {
        this.incomeList = response.Data;
        this.total = response.Total;
      }, err => {
      });
    }

  }
  //#endregion 
  getAllFarmAccount(dataSourceModel: any) {
    this.farmAccountService.getFarmAccountsByFarmId(this.farmId, dataSourceModel).subscribe(response => {
      this.farmAccountList = response.Data;
      this.farmAccountTotal = response.Total;
      this.paidUpTotal = response.Entity.PaidUpTotal;
    }, err => {
    });
  }
  //#region Deleteing
  public delete(id: number) {
    this.incomeService.delete(id)
      .subscribe((response) => {
        this.getAllIncomes(this.dataSourceModel);
      })
      , error => {
      }
  }
  //#endregion

  //#region Open Modal
  public openModal(id?: number) {
    const dialogRef = this.dialog.open(IncomeFormComponent, {
      width: '900px',
      // height: '400px',
      data: { id: id }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getAllIncomes(this.dataSourceModel);
      }
    });
  }
  //#endregion

  //#region Pagination
  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllIncomes(this.dataSourceModel);
  }
  public onChangeAccountPagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllFarmAccount(this.dataSourceModel);
  }

  //#endregion

  // print(): void {
  //   let dataSourceModel = new DataSourceModel();
  //   dataSourceModel.PageSize = 1000000000;

  //   var incomes: any = [];
  //   var accountList: any = [];

  //   this.incomeService.getIncomesByFarmId(this.farmId, dataSourceModel).subscribe(response => {
  //     incomes = response.Data;
  //   }, err => {
  //   });

  //   this.farmAccountService.getFarmAccountsByFarmId(this.farmId, dataSourceModel).subscribe(response => {
  //     accountList = response.Data;
  //   }, err => {
  //   });

  //   let printContents, popupWin;
  //   printContents = document.getElementById('print-section').innerHTML;
  //   popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
  //   popupWin.document.open();
  //   var html = `
  //     <html>
  //       <head>
  //         <title>Supplier Account</title>
  //         <style>
  //         </style>
  //       </head>
  //       <body onload="window.print()">
  //   <div class="wrapper" style="font-family: 'Helvetica Neue', lato, arial, sans-serif;font-size: 16px;">
  //   <table class="main-table" style="width: 100%;table-layout: fixed;">
  //     <tr>
  //       <td></td>
  //       <td width="1000">
  //         <div class="header" style="text-align: center;margin: 30px 0 50px 0;">
  //           <img src="//static.woopra.com/newsletters/woopra-logo-v2.png">
  //         </div>
  //         <div class="report" style="margin-bottom: 50px;">
  //           <h2 style="font-weight: 300;">Supplier Account</h2>

  //           <table class="report-table" style="width: 100%;table-layout: fixed;border-spacing: 0;border-collapse: separate;font-size: 14px;border: 1px solid #ddd;border-radius: 3px;" border="1">
  //             <thead>
  //               <tr>`;
  //   for (let property of this.properties) {
  //     html += `<th style="height: 36px;border-bottom: 1px solid #D3DEE4;color: black;text-align: left;padding: 0 8px;white-space: nowrap;overflow: hidden;text-overflow: ellipsis;">` + property + `</th>`;
  //   }

  //   html += `</tr>
  //             </thead>
  //             <tbody>`;
  //    html+=`<tr>
  //                 <td style="text-align: left;padding: 0 8px;white-space: nowrap;overflow: hidden;text-overflow: ellipsis;height: 42px;line-height: 42px;">Wed, Jul 29, 2015</td>
  //               </tr>

  //             </tbody>

  //             <tfoot>
  //               <tr>
  //                 <td style="text-align: left;padding: 0 8px;white-space: nowrap;overflow: hidden;text-overflow: ellipsis;height: 36px;line-height: 36px;font-weight: bold;color: #3F6984;background: #E8ECEF;">Total</td>
  //                 <td style="text-align: right;padding: 0 8px;white-space: nowrap;overflow: hidden;text-overflow: ellipsis;height: 36px;line-height: 36px;font-weight: bold;color: #3F6984;background: #E8ECEF;">40</td>
  //                 <td style="text-align: right;padding: 0 8px;white-space: nowrap;overflow: hidden;text-overflow: ellipsis;height: 36px;line-height: 36px;font-weight: bold;color: #3F6984;background: #E8ECEF;">150</td>
  //                 <td style="text-align: right;padding: 0 8px;white-space: nowrap;overflow: hidden;text-overflow: ellipsis;height: 36px;line-height: 36px;font-weight: bold;color: #3F6984;background: #E8ECEF;">-$9,312.12</td>
  //                 <td style="text-align: right;padding: 0 8px;white-space: nowrap;overflow: hidden;text-overflow: ellipsis;height: 36px;line-height: 36px;font-weight: bold;color: #3F6984;background: #E8ECEF;">$143.12</td>
  //                 <td style="text-align: right;padding: 0 8px;white-space: nowrap;overflow: hidden;text-overflow: ellipsis;height: 36px;line-height: 36px;font-weight: bold;color: #3F6984;background: #E8ECEF;">-$8,123.12</td>
  //               </tr>
  //             </tfoot>
  //           </table>
  //         </div>
  //         <div class="footer">
  //           <p> Developed by Mahmoud A.Salman &copy; 2020</p>
  //         </div>
  //       </td>
  //       <td></td>
  //     </tr>
  //   </table>
  // </div>
  //   </body>
  //     </html>`
  //   popupWin.document.write(html);
  //   popupWin.document.close();
  // }
}