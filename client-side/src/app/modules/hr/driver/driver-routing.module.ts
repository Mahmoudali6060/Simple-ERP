import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DriverListComponent } from './components/driver-list/driver-list.component';
import { TransferListComponent } from './components/transfer-list/transfer-list.component';

const routes: Routes = [
  { path: '', component: DriverListComponent },
  { path: 'transfer-list', component: TransferListComponent },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DriverRoutingModule {
}
