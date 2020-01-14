import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

export const routes: Routes = [
  { path: '', loadChildren: './modules/authentication/login/login.module#LoginModule' },
  { path: 'layout', loadChildren: './layout/layout.module#LayoutModule' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
