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
        path: 'transaction', loadChildren: () => import('../modules/accounting/transaction/transaction.module').then(m => m.TransactionModule)
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
      {
        path: 'debit-current', loadChildren: () => import('../modules/debit/current/current.module').then(m => m.CurrentModule)
      },
      {
        path: 'debit-borrow', loadChildren: () => import('../modules/debit/borrow/borrow.module').then(m => m.BorrowModule)
      },
      {
        path: 'safe', loadChildren: () => import('../modules/debit/safe/safe.module').then(m => m.SafeModule)
      },
      {
        path: 'credit-current', loadChildren: () => import('../modules/credit/current/current.module').then(m => m.CurrentModule)
      },
      {
        path: 'credit-borrow', loadChildren: () => import('../modules/credit/borrow/borrow.module').then(m => m.BorrowModule)
      },
      {
        path: 'salary', loadChildren: () => import('../modules/credit/salary/salary.module').then(m => m.SalaryModule)
      },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
