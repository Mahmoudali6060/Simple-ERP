import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { FarmRoutingModule } from './farm-routing.module';
import { FarmListComponent } from './components/farm-list/farm-list.component';
import { FarmAccountStatementComponent } from './components/farm-account-statement/farm-account-statement.component';
import { FarmService } from './services/farm.service';
import { FarmFormComponent } from './components/farm-form/farm-form.component';

@NgModule({
  imports: [
    FarmRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    FarmListComponent,
    FarmFormComponent,
    FarmAccountStatementComponent
  ],
  providers: [
    FarmService,
  ],
  entryComponents:[
    FarmFormComponent
  ]
})

export class FarmModule {
}
