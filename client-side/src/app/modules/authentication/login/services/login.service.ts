import { CookieService } from 'ngx-cookie-service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from '../../../../../environments/environment';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { LoginModel } from 'src/app/modules/authentication/login/models/login.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({ providedIn: 'root' })
export class LoginService {
  constructor( private http: HttpClient, private jwtHelper: JwtHelperService) { }

  isUserAuthenticated() {
    let token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }

  login(model: any) {
    return this.http.post("http://localhost:54095/api/auth/login", model, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  logOut() {
    localStorage.removeItem("jwt");
  }

}