import { ExportModel } from 'src/app/modules/farm/models/export.model';
import { PageSettingModel } from 'src/app/shared/models/page.model';

export class FarmModel {
    Id: number;
    OwnerName: string;
    OwnerMobile: string;
    Address: string;
    Notes: string;
    Incomes: any;
    Transfers: any;
}