import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule, registerLocaleData, DatePipe } from '@angular/common';
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
import { ErrorDialogService } from '../shared/services/error-dialof.sercive';
import { ErrorDialogComponent } from '../shared/components/error-dialog/error-dialog.component';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MaterialModule } from '../shared/modules/material.module';
import { PaginationComponent } from '../shared/components/pagination/pagination.component';
import { DataListComponent } from '../shared/components/data-list/data-list.component';
import { ConfirmationDialogComponent } from '../shared/components/confirmation-dialog/confirmation-dialog.component';
import { ModalBasicComponent } from 'src/app/shared/components/modal-basic/modal-basic.component';
import { MatDialogModule, MatDialogRef } from '@angular/material';
import { AuthGuardService } from 'src/app/shared/guards/auth-guard.service';


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
    MaterialModule,


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
    PaginationComponent,
    DataListComponent,
    MaterialModule
    // ModalBasicComponent
  ],
  declarations: [
    ErrorDialogComponent,
    ConfirmationDialogComponent,
    PaginationComponent,
    DataListComponent,
    ModalBasicComponent
  ],
  entryComponents: [
    ErrorDialogComponent,
    ConfirmationDialogComponent,
    DataListComponent,
    ModalBasicComponent
  ],
  providers: [
    BsModalService,
    ErrorDialogService,
    DatePipe,
    AuthGuardService
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
