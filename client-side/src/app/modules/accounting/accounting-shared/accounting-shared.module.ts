import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { CategorySelectComponent } from './components/category-select/category-select.component';
import { CategoryService } from './services/category.service';
import { FarmSelectComponent } from './components/farm-select/farm-select.component';
import { DriverSelectComponent } from './components/driver-select/driver-select.component';
import { DriverService } from '../../hr/driver/services/driver.service';
import { StationSelectComponent } from './components/station-select/station-select.component';
import { StationService } from '../../station/services/station.service';
import { ReaperSelectComponent } from './components/reaper-select/reaper-select.component';
import { ReaperService } from '../../hr/reaper/services/reaper.service';

@NgModule({
  imports: [
    SharedModule.forRoot()
  ],
  exports: [
    CategorySelectComponent,
    FarmSelectComponent,
    DriverSelectComponent,
    StationSelectComponent,
    ReaperSelectComponent
  ],
  declarations: [
    CategorySelectComponent,
    FarmSelectComponent,
    DriverSelectComponent,
    StationSelectComponent,
    ReaperSelectComponent

  ],
  providers: [
    CategoryService,
    DriverService,
    StationService,
    ReaperService

  ]
})

export class AccountingSharedModule {
}
