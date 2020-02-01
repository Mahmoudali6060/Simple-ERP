import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { ReaperRoutingModule } from './reaper-routing.module';
import { ReaperService } from './services/reaper.service';

@NgModule({
  imports: [
    ReaperRoutingModule,
    SharedModule.forRoot()
  ],
  declarations: [

  ],
  providers: [
    ReaperService,
  ]
})

export class ReaperModule {
}
