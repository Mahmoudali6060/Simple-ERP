import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginModel } from '../models/login.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoginService } from 'src/app/modules/authentication/login/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  invalidLogin: boolean = false;//For showing or error message in case invalid username or password

  constructor(private router: Router, private loginService: LoginService) {

  }

  login(form: NgForm) {
    let credentials = JSON.stringify(form.value);
    this.loginService.login(credentials).subscribe(response => {
      let token = (<any>response).token;
      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
      this.router.navigate(["/layout/dashboard"]);
    }, err => {
      this.invalidLogin = true;
    });
  }
}
