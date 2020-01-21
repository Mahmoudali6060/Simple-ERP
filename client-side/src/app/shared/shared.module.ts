import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { TranslateModule } from '@ngx-translate/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { defineLocale, arLocale, BsLocaleService, BsDatepickerModule, TooltipModule, BsModalService, ModalModule } from 'ngx-bootstrap';
import arSaLocale from '@angular/common/locales/ar-SA';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { ScrollToModule } from '@nicky-lenaers/ngx-scroll-to';
import { NgSelectModule } from '@ng-select/ng-select';
import { OrderModule } from 'ngx-order-pipe';
import { ErrorDialogService } from 'src/app/shared/services/error-dialof.sercive';
import { ErrorDialogComponent } from 'src/app/shared/components/error-dialog/error-dialog.component';
import { ConfirmationDialogService } from 'src/app/shared/components/confirmation-dialog/service/confirmation-dialog.service';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MaterialModule } from 'src/app/shared/modules/material.module';
import { PaginationComponent } from 'src/app/shared/components/pagination/pagination.component';

@NgModule({

  imports: [
    CommonModule,
    FormsModule,
    ToastrModule.forRoot(),
    SweetAlert2Module.forRoot(),
    BsDatepickerModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    ScrollToModule.forRoot(),
    TranslateModule,
    HttpClientModule,
    NgSelectModule,
    OrderModule,
    NgbModule,
    MaterialModule
  ],

  exports: [
    CommonModule,
    ToastrModule,
    FormsModule,
    TranslateModule,
    HttpClientModule,
    SweetAlert2Module,
    TooltipModule,
    ModalModule,
    ScrollToModule,
    NgSelectModule,
    BsDatepickerModule,
    OrderModule,
    NgbModule,
    PaginationComponent
  ],
  declarations: [
    ErrorDialogComponent,
    ConfirmationDialogComponent,
    PaginationComponent
  ],
  entryComponents: [
    ErrorDialogComponent,
    ConfirmationDialogComponent
  ],
  providers: [
    BsModalService,
    ErrorDialogService,
    ConfirmationDialogService
  ],
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule
    };
  }
}
registerLocaleData(arSaLocale);
defineLocale('ar', arLocale);
