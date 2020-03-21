import { Component } from '@angular/core';
declare var $: any;
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from 'src/app/modules/authentication/services/auth.service';
import { Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap';
import { DatabaseBackupComponent } from 'src/app/modules/database/components/database-backup/database-backup.component';
import { MatDialog } from '@angular/material';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {

  constructor(private translate: TranslateService,
    private authService: AuthService,
    private router: Router,
    private localeService: BsLocaleService,
    private dialog: MatDialog) {
    translate.setDefaultLang('ar');
    this.localeService.use('ar');
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
    this.localeService.use(language);

  }

  //#region Open Modal
  public openBackupModal(id?: number) {
    const dialogRef = this.dialog.open(DatabaseBackupComponent, {
      width: '900px'
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {

      }
    });
  }
  //#endregion

  public logOut() {
    this.authService.logOut();
    this.router.navigate(["/"]);
  }
}
