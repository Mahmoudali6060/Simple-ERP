import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { StationRoutingModule } from './station-routing.module';
import { StationListComponent } from './components/station-list/station-list.component';
import { StationAccountStatementComponent } from './components/station-account-statement/station-account-statement.component';
import { StationService } from './services/station.service';

@NgModule({
  imports: [
    StationRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    StationListComponent,
    StationAccountStatementComponent
  ],
  providers: [
    StationService,
  ]
})

export class StationModule {
}
