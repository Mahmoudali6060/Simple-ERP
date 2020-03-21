import { Injectable } from '@angular/core';
import { BaseEntityService } from 'src/app/shared/services/base-entity.service';

@Injectable()
export class SelectorDetailService extends BaseEntityService {
  entityName = "SelectorDetail";

  getAllBySelectorId(selectorId, dataSource): any {
    return this._http.post(`${this.baseUrl}api/${this.entityName}/GetAllBySelectorId/` + selectorId, dataSource);
  }
}