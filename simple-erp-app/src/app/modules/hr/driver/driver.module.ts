import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { DriverRoutingModule } from './driver-routing.module';
import { DriverService } from './services/driver.service';
import { TransferService } from './services/transfer.service';
import { DriverListComponent } from './components/driver-list/driver-list.component';
import { TransferListComponent } from './components/transfer-list/transfer-list.component';
import { DriverFormComponent } from './components/driver-form/driver-form.component';
import { DriverAccountService } from 'src/app/modules/hr/driver/services/driver-account.service';
import { ReportModule } from 'src/app/modules/report/report.module';

@NgModule({
  imports: [
    DriverRoutingModule,
    SharedModule.forRoot(),
    ReportModule
  ],
  declarations: [
    DriverListComponent,
    TransferListComponent,
    DriverFormComponent
  ],
  providers: [
    DriverService,
    TransferService,
    DriverAccountService
  ],
  entryComponents: [
    DriverFormComponent
  ]
})

export class DriverModule {
}
