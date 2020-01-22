import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FarmFormComponent } from 'src/app/modules/farm/components/farm-form/farm-form.component';
import { FarmListComponent } from 'src/app/modules/farm/components/farm-list/farm-list.component';
import { ExportListComponent } from 'src/app/modules/farm/components/export-list/export-list.component';
import { ExportFormComponent } from 'src/app/modules/farm/components/export-form/export-form.component';

const routes: Routes = [
  { path: '', component: FarmListComponent },
  { path: 'farm-list', component: FarmListComponent },
  { path: 'farm-form', component: FarmFormComponent },
  { path: 'farm-form/:id', component: FarmFormComponent },
  { path: 'export-list', component: ExportListComponent },
  { path: 'export-form', component: ExportFormComponent },
  { path: 'export-form/:id', component: ExportFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FarmRoutingModule {
}
