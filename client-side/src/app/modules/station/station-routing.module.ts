import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StationFormComponent } from 'src/app/modules/station/components/station-form/station-form.component';
import { StationListComponent } from 'src/app/modules/station/components/station-list/station-list.component';
import { IncomeListComponent } from 'src/app/modules/station/components/income-list/income-list.component';
import { IncomeFormComponent } from 'src/app/modules/station/components/income-form/income-form.component';
import { StationAccountStatementComponent } from 'src/app/modules/station/components/station-account-statement/station-account-statement.component';

const routes: Routes = [
  { path: '', component: StationListComponent },
  { path: 'station-list', component: StationListComponent },
  { path: 'station-form', component: StationFormComponent },
  { path: 'station-form/:id', component: StationFormComponent },
  { path: 'income-list', component: IncomeListComponent },
  { path: 'income-form', component: IncomeFormComponent },
  { path: 'income-form/:id', component: IncomeFormComponent },
  { path: 'station-account-statement/:stationId/:stationName', component: StationAccountStatementComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StationRoutingModule {
}
