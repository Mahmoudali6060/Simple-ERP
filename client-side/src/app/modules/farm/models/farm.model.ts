import { ExportModel } from 'src/app/modules/farm/models/export.model';
import { PageSettingModel } from 'src/app/shared/models/page.model';

export class FarmModel extends PageSettingModel {
    Id: number;
    OwnerName: string;
    OwnerMobile: string;
    Address: string;
    Notes: string;
    Exports: Array<ExportModel>;
}