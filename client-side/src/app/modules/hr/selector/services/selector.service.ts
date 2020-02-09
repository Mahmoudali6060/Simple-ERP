import { Injectable } from '@angular/core';
import { BaseEntityService } from 'src/app/shared/services/base-entity.service';

@Injectable()
export class SelectorService extends BaseEntityService {
  entityName = "Selector";
}