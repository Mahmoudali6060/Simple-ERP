import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { DriverRoutingModule } from './driver-routing.module';
import { DriverService } from './services/driver.service';
import { TransferService } from './services/transfer.service';
import { DriverListComponent } from './components/driver-list/driver-list.component';
import { TransferListComponent } from './components/transfer-list/transfer-list.component';

@NgModule({
  imports: [
    DriverRoutingModule,
    SharedModule.forRoot()
  ],
  declarations: [
    DriverListComponent,
    TransferListComponent
  ],
  providers: [
    DriverService,
    TransferService
  ]
})

export class DriverModule {
}
