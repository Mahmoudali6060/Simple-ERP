import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BorrowListComponent } from './components/borrow-list/borrow-list.component';

const routes: Routes = [
  { path: '', component: BorrowListComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BorrowRoutingModule {
}
