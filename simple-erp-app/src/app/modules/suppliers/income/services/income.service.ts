import { CookieService } from 'ngx-cookie-service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from '../../../../../environments/environment';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { BaseEntityService } from 'src/app/shared/services/base-entity.service';

@Injectable()
export class IncomeService extends BaseEntityService {

  entityName = "Income";

  getIncomesByFarmId(farmId, dataSource): any {
    return this._http.post(`${this.baseUrl}api/${this.entityName}/GetIncomesByFarmId/` + farmId, dataSource);
  }
}