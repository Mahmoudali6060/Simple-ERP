import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { FarmRoutingModule } from './farm-routing.module';
import { FarmListComponent } from './components/farm-list/farm-list.component';
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
