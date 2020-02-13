import { Component } from '@angular/core';
declare var $: any;
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from 'src/app/modules/authentication/services/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {

  constructor(private translate: TranslateService, private authService: AuthService, private router: Router) {
    translate.setDefaultLang('ar');
    console.log("loaded the header");

  }

  public toggleSideMenu() {

    if (!$('body').hasClass('layout-fullwidth')) {
      $('body').addClass('layout-fullwidth');

    } else {
      $('body').removeClass('layout-fullwidth');
      $('body').removeClass('layout-default'); // also remove default behaviour if set
    }

    $(this).find('.lnr').toggleClass('lnr-arrow-left-circle lnr-arrow-right-circle');

    if ($(window).innerWidth() < 1025) {
      if (!$('body').hasClass('offcanvas-active')) {
        $('body').addClass('offcanvas-active');
      } else {
        $('body').removeClass('offcanvas-active');
      }
    }

  }

  public switchLanguage(language: string) {
    this.translate.use(language);
  }

  public logOut() {
    this.authService.logOut();
    this.router.navigate(["/"]);
  }
}
