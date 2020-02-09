import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { FarmRoutingModule } from './farm-routing.module';
import { FarmListComponent } from './components/farm-list/farm-list.component';
import { FarmAccountStatementComponent } from './components/farm-account-statement/farm-account-statement.component';
import { FarmService } from './services/farm.service';

@NgModule({
  imports: [
    FarmRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    FarmListComponent,
    FarmAccountStatementComponent
  ],
  providers: [
    FarmService,
  ]
})

export class FarmModule {
}
