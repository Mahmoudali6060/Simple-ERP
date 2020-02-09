import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SelectorListComponent } from './components/selector-list/selector-list.component';

const routes: Routes = [
  { path: '', component: SelectorListComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SelectorRoutingModule {
}
