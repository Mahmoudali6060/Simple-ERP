import { Injectable } from '@angular/core';
import { BaseEntityService } from '../../../../shared/services/base-entity.service';

@Injectable()
export class ReaperDetailService extends BaseEntityService {
  entityName = "ReaperDetail";

  getAllByReaperId(reaperId, dataSource): any {
    return this._http.post(`${this.baseUrl}api/${this.entityName}/GetAllByReaperId/` + reaperId, dataSource);
  }
}