import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { OutcomeRoutingModule } from './outcome-routing.module';
import { OutcomeListComponent } from './components/outcome-list/outcome-list.component';
import { OutcomeService } from './services/outcome.service';

@NgModule({
  imports: [
    OutcomeRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    OutcomeListComponent,
  ],
  providers: [
    OutcomeService,
  ]
})

export class OutcomeModule {
}
