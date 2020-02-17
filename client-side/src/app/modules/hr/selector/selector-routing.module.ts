import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SelectorListComponent } from './components/selector-list/selector-list.component';
import { SelectorDetailListComponent } from './components/selector-detail-list/selector-detail-list.component';

const routes: Routes = [
  { path: '', component: SelectorListComponent },
  { path: 'selector-detail-list/:selectorId', component: SelectorDetailListComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SelectorRoutingModule {
}
