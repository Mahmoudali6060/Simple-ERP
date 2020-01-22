import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { FarmRoutingModule } from 'src/app/modules/farm/farm-routing.module';
import { FarmListComponent } from 'src/app/modules/farm/components/farm-list/farm-list.component';
import { FarmFormComponent } from 'src/app/modules/farm/components/farm-form/farm-form.component';
import { FarmService } from 'src/app/modules/farm/services/farm.service';
import { ExportService } from 'src/app/modules/farm/services/export.service';
import { ExportFormComponent } from 'src/app/modules/farm/components/export-form/export-form.component';
import { ExportListComponent } from 'src/app/modules/farm/components/export-list/export-list.component';

@NgModule({
  imports: [
    FarmRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    FarmListComponent,
    FarmFormComponent,
    ExportListComponent,
    ExportFormComponent
  ],
  providers: [
    FarmService,
    ExportService
  ]
})

export class FarmModule {
}
