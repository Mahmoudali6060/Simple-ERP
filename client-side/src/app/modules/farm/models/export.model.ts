import { FarmModel } from 'src/app/modules/farm/models/farm.model';
import { PageSettingModel } from 'src/app/shared/models/page.model';

export class ExportModel extends PageSettingModel {
    Id: number;
    Date: Date;
    FarmId: number;
    CarPlate: string;
    Weight: number;
    Pardon: number;
    WeightAfterPardon: number;
    Price: number;
    Debit: number;
    Credit: number;
    Total: number;
    Notes: string;
    Farm: FarmModel;
}