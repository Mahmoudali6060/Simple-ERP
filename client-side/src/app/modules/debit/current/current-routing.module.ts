import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CurrentListComponent } from './components/current-list/current-list.component';

const routes: Routes = [
  { path: '', component: CurrentListComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CurrentRoutingModule {
}
