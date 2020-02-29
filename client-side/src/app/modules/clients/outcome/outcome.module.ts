import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { OutcomeRoutingModule } from './outcome-routing.module';
import { OutcomeListComponent } from './components/outcome-list/outcome-list.component';
import { OutcomeService } from './services/outcome.service';
import { StationAccountService } from './services/station-account.service';
import { ReportModule } from 'src/app/modules/report/report.module';

@NgModule({
  imports: [
    OutcomeRoutingModule,
    SharedModule.forRoot(),
    ReportModule

  ],
  declarations: [
    OutcomeListComponent,
  ],
  providers: [
    OutcomeService,
    StationAccountService
  ]
})

export class OutcomeModule {
}
