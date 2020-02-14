import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { BorrowRoutingModule } from './borrow-routing.module';
import { BorrowListComponent } from './components/borrow-list/borrow-list.component';
import { BorrowService } from './services/borrow.service';
import { BorrowFormComponent } from './components/borrow-form/borrow-form.component';

@NgModule({
  imports: [
    BorrowRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    BorrowListComponent,
    BorrowFormComponent,
  ],
  providers: [
    BorrowService,
  ],
  entryComponents:[
    BorrowFormComponent
  ]
})

export class BorrowModule {
}
