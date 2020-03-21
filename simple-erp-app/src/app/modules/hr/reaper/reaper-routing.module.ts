import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReaperListComponent } from './components/reaper-list/reaper-list.component';
import { AuthGuardService } from '../../../shared/guards/auth-guard.service';
import { ReaperDetailListComponent } from './components/reaper-detail-list/reaper-detail-list.component';

const routes: Routes = [
  { path: '', component: ReaperListComponent },
  { path: 'reaper-detail-list/:reaperId', component: ReaperDetailListComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReaperRoutingModule {
}
