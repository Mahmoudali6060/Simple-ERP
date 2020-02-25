import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { CategorySelectComponent } from './components/category-select/category-select.component';
import { CategoryService } from './services/category.service';
import { FarmSelectComponent } from './components/farm-select/farm-select.component';
import { DriverSelectComponent } from './components/driver-select/driver-select.component';
import { DriverService } from '../../hr/driver/services/driver.service';
import { StationSelectComponent } from './components/station-select/station-select.component';
import { StationService } from '../../clients/station/services/station.service';
import { ReaperSelectComponent } from './components/reaper-select/reaper-select.component';
import { ReaperService } from '../../hr/reaper/services/reaper.service';
import { SelectorSelectComponent } from './components/selector-select/selector-select.component';
import { SelectorService } from '../../hr/selector/services/selector.service';
import { FarmService } from 'src/app/modules/suppliers/farm/services/farm.service';

@NgModule({
  imports: [
    SharedModule.forRoot()
  ],
  exports: [
    CategorySelectComponent,
    FarmSelectComponent,
    DriverSelectComponent,
    StationSelectComponent,
    ReaperSelectComponent,
    SelectorSelectComponent
  ],
  declarations: [
    CategorySelectComponent,
    FarmSelectComponent,
    DriverSelectComponent,
    StationSelectComponent,
    ReaperSelectComponent,
    SelectorSelectComponent

  ],
  providers: [
    CategoryService,
    DriverService,
    StationService,
    ReaperService,
    SelectorService,
    FarmService
  ]
})

export class AccountingSharedModule {
}
