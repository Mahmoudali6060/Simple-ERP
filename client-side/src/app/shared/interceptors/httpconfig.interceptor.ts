import { Injectable } from '@angular/core';
// import { ErrorDialogService } from '../error-dialog/errordialog.service';
import { HttpInterceptor, HttpRequest, HttpResponse, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { ErrorDialogService } from 'src/app/shared/services/error-dialof.sercive';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {

    constructor(private spinner: NgxSpinnerService, private errorDialogService: ErrorDialogService) {

    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.spinner.show();

        const token: string = localStorage.getItem('token');

        if (token) {
            request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
        }

        if (!request.headers.has('Content-Type')) {
            request = request.clone({ headers: request.headers.set('Content-Type', 'application/json') });
        }

        request = request.clone({ headers: request.headers.set('Accept', 'application/json') });

        return next.handle(request).pipe(
            map((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {
                    this.spinner.hide();
                    catchError((error: HttpErrorResponse) => {
                        let data = {};
                        data = {
                            reason: error && error.error.reason ? error.error.reason : '',
                            status: error.status
                        };
                        this.errorDialogService.openDialog(data);
                        return throwError(error);
                    })
                }
                // 
                return event;
            }));
    }
}