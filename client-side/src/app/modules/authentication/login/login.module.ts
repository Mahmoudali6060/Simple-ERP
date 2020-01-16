import { NgModule } from '@angular/core';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login/login.component';
import { SharedModule } from '../../../shared/shared.module';
import { LoginService } from 'src/app/modules/authentication/login/services/login.service';

@NgModule({
  imports: [
    LoginRoutingModule,
    SharedModule.forRoot()
  ],
  declarations: [
    LoginComponent
  ],
  providers: [
    LoginService
  ]
})

export class LoginModule {
}
