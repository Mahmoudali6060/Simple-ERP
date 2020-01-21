import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StationFormComponent } from 'src/app/modules/station/components/station-form/station-form.component';
import { StationListComponent } from 'src/app/modules/station/components/station-list/station-list.component';

const routes: Routes = [
  { path: '', component: StationListComponent },
  { path: 'station-list', component: StationListComponent },
  { path: 'station-form', component: StationFormComponent },
  { path: 'station-form/:id', component: StationFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StationRoutingModule {
}
