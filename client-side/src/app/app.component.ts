import { Component, ViewEncapsulation } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})

export class AppComponent {

  constructor( private jwtHelper: JwtHelperService, private router: Router) {

  }

  ngOnInit() {
   
  }

  isUserAuthenticated() {
    let token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }

  public logOut = () => {
    localStorage.removeItem("jwt");
  }
}

