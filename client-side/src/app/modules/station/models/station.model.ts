import { IncomeModel } from 'src/app/modules/station/models/income.model';
import { PageSettingModel } from 'src/app/shared/models/page.model';

export class StationModel extends PageSettingModel {
    Id: number;
    OwnerName: string;
    OwnerMobile: string;
    Address: string;
    Notes: string;
    Incomes: Array<IncomeModel>;
}