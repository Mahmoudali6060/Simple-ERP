import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { IncomeRoutingModule } from './income-routing.module';
import { IncomeListComponent } from './components/income-list/income-list.component';
import { IncomeService } from './services/income.service';
import { FarmAccountService } from 'src/app/modules/suppliers/income/services/farm-account.service';
import { ReportModule } from 'src/app/modules/report/report.module';

@NgModule({
  imports: [
    IncomeRoutingModule,
    SharedModule.forRoot(),
    ReportModule

  ],
  declarations: [
    IncomeListComponent,
  ],
  providers: [
    IncomeService,
    FarmAccountService
  ]
})

export class IncomeModule {
}
