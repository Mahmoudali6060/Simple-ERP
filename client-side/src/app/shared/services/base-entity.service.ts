import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';

import { environment } from '../../../environments/environment';
import { CRUDOperation } from '../../shared/enums/CRUD-Operation.enum';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/internal/operators/catchError';

@Injectable(
    { providedIn: 'root' }
)
export class BaseEntityService {
    baseUrl: string = "";
    urlGetAll = "GetAll";
    urlGetById = "GetById";
    urlAdd = "Add";
    urlUpdate = "Update";
    urlDelete = "Delete";
    urlGetAllLite = "GetAllLite";
    entityName: string = "";

    constructor(public _http: HttpClient) {
        this.baseUrl = environment.apiUrl;
    }

    getAll(model): any {
        return this._http.post(this.baseUrl + 'api/' + this.entityName + '/' + this.urlGetAll, model);
        // //     .subscribe((response: Response) => response.json())
        // //     , catchError(this.errorHandler);
    }

    getAllLite(): any {
        return this._http.get(this.baseUrl + 'api/' + this.entityName + '/' + this.urlGetAllLite);
        // //     .subscribe((response: Response) => response.json())
        // //     , catchError(this.errorHandler);
    }
    getById(id: number): any {
        return this._http.get(this.baseUrl + "api/" + this.entityName + '/' + this.urlGetById + '/' + id);
        // .subscribe((response: Response) => response.json())
        // , catchError(this.errorHandler);
    }

    save(entity) {
        if (entity.id) {
            return this.update(entity);
        }
        else {
            return this.add(entity);
        }
    }

    add(entity) {
        return this._http.post(this.baseUrl + "api/" + this.entityName + "/" + this.urlAdd + "/", entity);
    }

    update(entity) {
        return this._http.post(this.baseUrl + "api/" + this.entityName + "/" + this.urlUpdate + "/", entity);
        // .subscribe((response: Response) => response.json())
        // , catchError(this.errorHandler);
    }

    delete(id) {
        return this._http.delete(this.baseUrl + "api/" + this.entityName + "/" + this.urlDelete + "/" + id);
        // .subscribe((response: Response) => response.json())
        // , catchError(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}
