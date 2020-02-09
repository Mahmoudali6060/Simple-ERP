import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FullLayoutComponent } from './full-layout/full-layout.component';

export const routes: Routes = [
  {
    path: '',
    component: FullLayoutComponent,
    children: [
      {
        path: 'dashboard', loadChildren: () => import('../modules/dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'farm', loadChildren: () => import('../modules/suppliers/farm/farm.module').then(m => m.FarmModule)
      },
      {
        path: 'income', loadChildren: () => import('../modules/suppliers/income/income.module').then(m => m.IncomeModule)
      },
      {
        path: 'station', loadChildren: () => import('../modules/clients/station/station.module').then(m => m.StationModule)
      },
      {
        path: 'outcome', loadChildren: () => import('../modules/clients/outcome/outcome.module').then(m => m.OutcomeModule)
      },
      {
        path: 'transaction', loadChildren: () => import('../modules/transaction/transaction.module').then(m => m.TransactionModule)
      },

      {
        path: 'driver', loadChildren: () => import('../modules/hr/driver/driver.module').then(m => m.DriverModule)
      },

      {
        path: 'selector', loadChildren: () => import('../modules/hr/selector/selector.module').then(m => m.SelectorModule)
      },
      {
        path: 'reaper', loadChildren: () => import('../modules/hr/reaper/reaper.module').then(m => m.ReaperModule)
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
