import { StationModel } from 'src/app/modules/station/models/station.model';
import { PageSettingModel } from 'src/app/shared/models/page.model';

export class IncomeModel extends PageSettingModel {
    Id: number;
    Date: Date;
    StationId: number;
    CarPlate: string;
    Weight: number;
    Price: number;
    Debit: number;
    Credit: number;
    Total: number;
    Notes: string;
    Station: StationModel;
}