import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { StationRoutingModule } from 'src/app/modules/station/station-routing.module';
import { StationListComponent } from 'src/app/modules/station/components/station-list/station-list.component';
import { StationFormComponent } from 'src/app/modules/station/components/station-form/station-form.component';
import { StationService } from 'src/app/modules/station/services/station.service';
import { IncomeFormComponent } from 'src/app/modules/station/components/income-form/income-form.component';
import { IncomeListComponent } from 'src/app/modules/station/components/income-list/income-list.component';
import { IncomeService } from 'src/app/modules/station/services/income.service';
import { StationAccountStatementComponent } from 'src/app/modules/station/components/station-account-statement/station-account-statement.component';

@NgModule({
  imports: [
    StationRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    StationListComponent,
    StationFormComponent,
    IncomeFormComponent,
    IncomeListComponent,
    StationAccountStatementComponent
  ],
  providers: [
    StationService,
    IncomeService
  ]
})

export class StationModule {
}
