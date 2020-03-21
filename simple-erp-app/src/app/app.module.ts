import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { NgxSpinnerModule } from 'ngx-spinner';
import { JwtModule } from "@auth0/angular-jwt";
import { HttpConfigInterceptor } from './shared/interceptors/httpconfig.interceptor';
import { MatDialogModule } from '@angular/material/dialog';
import { AuthModule } from 'src/app/modules/authentication/auth.module';

import { DxReportDesignerModule } from 'devexpress-reporting-angular';
import { SpinnerInterceptor } from 'src/app/shared/interceptors/spinner.interceptor';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    SharedModule.forRoot(),
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    NgxSpinnerModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
        // whitelistedDomains: ["localhost:54095"],
        // blacklistedRoutes: []
      }
    }),
    MatDialogModule,
    AuthModule,
    DxReportDesignerModule

  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: SpinnerInterceptor, multi: true },
  ],

  bootstrap: [AppComponent]
})
export class AppModule {




}

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

// export function HttpLoaderFactory(http: HttpClient) {
//   return new TranslateHttpLoader(http, 'assets/i18n/', '.json');
// }