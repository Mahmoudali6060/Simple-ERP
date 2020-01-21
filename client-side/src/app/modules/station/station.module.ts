import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { StationRoutingModule } from 'src/app/modules/station/station-routing.module';
import { StationListComponent } from 'src/app/modules/station/components/station-list/station-list.component';
import { StationFormComponent } from 'src/app/modules/station/components/station-form/station-form.component';
import { StationService } from 'src/app/modules/station/services/station.service';

@NgModule({
  imports: [
    StationRoutingModule,
    SharedModule.forRoot()
    
  ],
  declarations: [
    StationListComponent,
    StationFormComponent
  ],
  providers: [
    StationService
  ]
})

export class StationModule {
}
