import { Injectable } from '@angular/core';
import { BaseEntityService } from '../../../../shared/services/base-entity.service';

@Injectable()
export class ReaperDetailService extends BaseEntityService {
  entityName = "ReaperDetail";
}