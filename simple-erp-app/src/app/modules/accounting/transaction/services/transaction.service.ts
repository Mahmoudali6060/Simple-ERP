import { Injectable } from '@angular/core';
import { BaseEntityService } from '../../../../shared/services/base-entity.service';

@Injectable()
export class TransactionService extends BaseEntityService {
  entityName = "Transaction";

}