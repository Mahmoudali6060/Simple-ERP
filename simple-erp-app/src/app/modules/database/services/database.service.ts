import { Injectable } from '@angular/core';
import { DatePipe } from '@angular/common';
import { environment } from 'src/environments/environment';
import { BaseEntityService } from 'src/app/shared/services/base-entity.service';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class DatabaseService extends BaseEntityService {

  backupdDatabase(model: any) {
    return this._http.post(`${this.baseUrl}/api/Database/BackupDatabase`, model, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }
}