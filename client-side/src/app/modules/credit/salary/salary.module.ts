import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { SalaryRoutingModule } from './salary-routing.module';
import { SalaryListComponent } from './components/salary-list/salary-list.component';
import { SalaryService } from './services/salary.service';
import { SalaryFormComponent } from './components/salary-form/salary-form.component';

@NgModule({
  imports: [
    SalaryRoutingModule,
    SharedModule.forRoot()

  ],
  declarations: [
    SalaryListComponent,
    SalaryFormComponent,
  ],
  providers: [
    SalaryService,
  ],
  entryComponents:[
    SalaryFormComponent
  ]
})

export class SalaryModule {
}
