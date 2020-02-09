import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { IncomeRoutingModule } from './income-routing.module';
import { IncomeListComponent } from './components/income-list/income-list.component';
import { IncomeService } from './services/income.service';

@NgModule({
  imports: [
    IncomeRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    IncomeListComponent,
  ],
  providers: [
    IncomeService,
  ]
})

export class IncomeModule {
}
