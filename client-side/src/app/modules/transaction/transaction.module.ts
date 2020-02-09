import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { TransactionService } from './services/transaction.service';
import { TransactionFormComponent } from './components/transaction-form/transaction-form.component';
import { TransactionRoutingModule } from './transaction-routing.module';
import { FarmService } from '../../modules/suppliers/farm/services/farm.service';
import { AccountingSharedModule } from '../accounting/accounting-shared/accounting-shared.module';
import { TransactionListComponent } from './components/transaction-list/transaction-list.component';

@NgModule({
  imports: [
    TransactionRoutingModule,
    SharedModule.forRoot(),
    AccountingSharedModule
  ],
  declarations: [
    TransactionFormComponent,
    TransactionListComponent
  ],
  providers: [
    TransactionService,
    FarmService
    
  ]
})

export class TransactionModule {
}
