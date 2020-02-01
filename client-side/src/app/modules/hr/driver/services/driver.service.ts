import { Injectable } from '@angular/core';
import { BaseEntityService } from 'src/app/shared/services/base-entity.service';

@Injectable()
export class DriverService extends BaseEntityService {
  entityName = "Driver";
}