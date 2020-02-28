import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { SelectorRoutingModule } from './selector-routing.module';
import { SelectorService } from './services/selector.service';
import { SelectorListComponent } from './components/selector-list/selector-list.component';
import { SelectorDetailListComponent } from './components/selector-detail-list/selector-detail-list.component';
import { SelectorFormComponent } from './components/selector-form/selector-form.component';
import { SelectorDetailService } from './services/selector-detail.service';
import { SelectorAccountService } from './services/selector-account.service';

@NgModule({
  imports: [
    SelectorRoutingModule,
    SharedModule.forRoot()
  ],
  declarations: [
    SelectorListComponent,
    SelectorDetailListComponent,
    SelectorFormComponent
  ],
  providers: [
    SelectorService,
    SelectorDetailService,
    SelectorAccountService
  ],
  entryComponents: [
    SelectorFormComponent
  ]
})

export class SelectorModule {
}
