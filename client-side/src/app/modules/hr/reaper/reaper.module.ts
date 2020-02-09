import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { ReaperRoutingModule } from './reaper-routing.module';
import { ReaperService } from './services/reaper.service';
import { ReaperListComponent } from './components/reaper-list/reaper-list.component';
import { ReaperDetailListComponent } from './components/reaper-detail-list/reaper-detail-list.component';
import { ReaperDetailService } from './services/reaper-detail.service';

@NgModule({
  imports: [
    ReaperRoutingModule,
    SharedModule.forRoot()
  ],
  declarations: [
    ReaperListComponent,
    ReaperDetailListComponent
  ],
  providers: [
    ReaperService,
    ReaperDetailService
  ]
})

export class ReaperModule {
}
