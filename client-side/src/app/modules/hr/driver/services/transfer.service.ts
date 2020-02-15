import { Injectable } from '@angular/core';
import { BaseEntityService } from 'src/app/shared/services/base-entity.service';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class TransferService extends BaseEntityService {
  entityName = "Transfer";


  getAllByDriverId(driverId, dataSource): any {
    return this._http.post(`${this.baseUrl}api/${this.entityName}/GetAllByDriverId/` + driverId, dataSource);
  }
}