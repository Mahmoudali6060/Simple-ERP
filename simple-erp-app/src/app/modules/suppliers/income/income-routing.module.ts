import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IncomeListComponent } from './components/income-list/income-list.component';

const routes: Routes = [
  { path: '', component: IncomeListComponent },
  { path: 'income-list/:farmId', component: IncomeListComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IncomeRoutingModule {
}
