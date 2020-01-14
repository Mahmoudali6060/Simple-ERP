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

@NgModule({
  declarations: [
  
  ],
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
  ],
  providers: [
    BsModalService
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
  ]
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
