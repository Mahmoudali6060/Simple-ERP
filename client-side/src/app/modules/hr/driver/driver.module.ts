import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { DriverRoutingModule } from './driver-routing.module';
import { DriverService } from './services/driver.service';

@NgModule({
  imports: [
    DriverRoutingModule,
    SharedModule.forRoot()
  ],
  declarations: [

  ],
  providers: [
    DriverService,
  ]
})

export class DriverModule {
}
