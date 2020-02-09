import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { SelectorRoutingModule } from './selector-routing.module';
import { SelectorService } from './services/selector.service';
import { SelectorListComponent } from './components/selector-list/selector-list.component';

@NgModule({
  imports: [
    SelectorRoutingModule,
    SharedModule.forRoot()
  ],
  declarations: [
    SelectorListComponent
  ],
  providers: [
    SelectorService
  ]
})

export class SelectorModule {
}
