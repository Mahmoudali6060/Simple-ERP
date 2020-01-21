import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { FarmRoutingModule } from 'src/app/modules/farm/farm-routing.module';
import { FarmListComponent } from 'src/app/modules/farm/components/farm-list/farm-list.component';
import { FarmFormComponent } from 'src/app/modules/farm/components/farm-form/farm-form.component';
import { FarmService } from 'src/app/modules/farm/services/farm.service';

@NgModule({
  imports: [
    FarmRoutingModule,
    SharedModule.forRoot()
    
  ],
  declarations: [
    FarmListComponent,
    FarmFormComponent
  ],
  providers: [
    FarmService
  ]
})

export class FarmModule {
}
