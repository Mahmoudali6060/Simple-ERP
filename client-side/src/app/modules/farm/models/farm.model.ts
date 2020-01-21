import { ExportModel } from 'src/app/modules/farm/models/export.model';
import { PageSettingModel } from 'src/app/shared/models/page.model';

export class FarmModel extends PageSettingModel {
    id: number;
    ownerName: string;
    ownerMobile: string;
    address: string;
    notes: string;
    exports: Array<ExportModel>;
}