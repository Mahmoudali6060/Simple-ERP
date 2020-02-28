import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { ReaperRoutingModule } from './reaper-routing.module';
import { ReaperService } from './services/reaper.service';
import { ReaperListComponent } from './components/reaper-list/reaper-list.component';
import { ReaperDetailListComponent } from './components/reaper-detail-list/reaper-detail-list.component';
import { ReaperDetailService } from './services/reaper-detail.service';
import { ReaperFormComponent } from './components/reaper-form/reaper-form.component';
import { ReaperAccountService } from 'src/app/modules/hr/reaper/services/reaper-account.service';

@NgModule({
  imports: [
    ReaperRoutingModule,
    SharedModule.forRoot()
  ],
  declarations: [
    ReaperListComponent,
    ReaperDetailListComponent,
    ReaperFormComponent
  ],
  providers: [
    ReaperService,
    ReaperDetailService,
    ReaperAccountService
  ],
  entryComponents: [
    ReaperFormComponent
  ]
})

export class ReaperModule {
}
