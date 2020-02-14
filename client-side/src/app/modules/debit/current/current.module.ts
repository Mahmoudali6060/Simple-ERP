import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { CurrentRoutingModule } from './current-routing.module';
import { CurrentListComponent } from './components/current-list/current-list.component';
import { CurrentService } from './services/current.service';
import { CurrentFormComponent } from './components/current-form/current-form.component';

@NgModule({
  imports: [
    CurrentRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    CurrentListComponent,
    CurrentFormComponent,
  ],
  providers: [
    CurrentService,
  ],
  entryComponents:[
    CurrentFormComponent
  ]
})

export class CurrentModule {
}
