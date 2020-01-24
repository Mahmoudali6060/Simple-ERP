import { CookieService } from 'ngx-cookie-service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from '../../../../environments/environment';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { BaseEntityService } from 'src/app/shared/services/base-entity.service';

@Injectable()
export class ExportService extends BaseEntityService {

  entityName = "Export";

  getAllExportsByFarmId(farmId: number): any {
    return this._http.get(this.baseUrl + "api/" + this.entityName + '/GetExportsByFarmId/' + farmId);
  }
}