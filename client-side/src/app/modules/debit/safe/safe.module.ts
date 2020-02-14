import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { SafeRoutingModule } from './safe-routing.module';
import { SafeListComponent } from './components/safe-list/safe-list.component';
import { SafeService } from './services/safe.service';
import { SafeFormComponent } from './components/safe-form/safe-form.component';

@NgModule({
  imports: [
    SafeRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    SafeListComponent,
    SafeFormComponent,
  ],
  providers: [
    SafeService,
  ],
  entryComponents:[
    SafeFormComponent
  ]
})

export class SafeModule {
}
