import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { environment } from '../../../environments/environment';
import { HttpClient } from 'selenium-webdriver/http';
import { CRUDOperation } from '../../shared/enums/CRUD-Operation.enum';

@Injectable()
export class BaseEntityService {
    baseUrl: string = "";
    urlGetAll = CRUDOperation.GetAll;
    urlGetById = CRUDOperation.GetById;
    urlAdd = CRUDOperation.Add;
    urlUpdate = CRUDOperation.Update;
    urlDelete = CRUDOperation.Delete;
    entityName: string = "";
    constructor(private _http: HttpClient) {
        this.baseUrl = environment.apiUrl;
    }

    // getAll() {
    //     return this._http.get(this.baseUrl + 'api/' + this.entityName + '/' + this.urlGetAll)
    //         .map((response: Response) => response.json())
    //         .catch(this.errorHandler);
    // }

    // getById(id: number) {
    //     return this._http.get(this.baseUrl + "api/" + this.entityName + '/' + this.urlGetById + '/' + id)
    //         .map((response: Response) => response.json())
    //         .catch(this.errorHandler)
    // }

    // add(entity) {
    //     return this._http.post(this.baseUrl + "api/" + this.entityName + "/" + this.urlAdd + "/", entity)
    //         .map((response: Response) => response.json())
    //         .catch(this.errorHandler)
    // }

    // update(entity) {
    //     return this._http.put(this.baseUrl + "api/" + this.entityName + "/" + this.urlUpdate, entity)
    //         .map((response: Response) => response.json())
    //         .catch(this.errorHandler);
    // }

    // delete(id) {
    //     return this._http.delete(this.baseUrl + "api/" + this.entityName + "/" + this.urlDelete + "/" + id)
    //         .map((response: Response) => response.json())
    //         .catch(this.errorHandler);
    // }

    // errorHandler(error: Response) {
    //     console.log(error);
    //     return Observable.throw(error);
    // }
}
