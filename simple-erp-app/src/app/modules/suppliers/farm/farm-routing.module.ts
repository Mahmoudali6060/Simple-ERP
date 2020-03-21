import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FarmListComponent } from './components/farm-list/farm-list.component';

const routes: Routes = [
  { path: '', component: FarmListComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FarmRoutingModule {
}
