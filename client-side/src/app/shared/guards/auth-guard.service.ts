import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Router } from '@angular/router';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable()
export class AuthGuardService implements CanActivate {
    constructor(private jwtHelper: JwtHelperService, private router: Router) {
    }
    canActivate() {
        var token = localStorage.getItem("jwt");

        if (token && !this.jwtHelper.isTokenExpired(token)) {
            return true;
        }
        this.router.navigate(["login"]);
        return false;
    }
    getToken() {
        return localStorage.getItem("jwt");
    }
}