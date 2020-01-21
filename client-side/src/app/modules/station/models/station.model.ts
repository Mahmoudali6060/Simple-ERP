import { IncomeModel } from 'src/app/modules/station/models/income.model';
import { PageSettingModel } from 'src/app/shared/models/page.model';

export class StationModel extends PageSettingModel {
    id: number;
    name: string;
    ownerMobile: string;
    address: string;
    notes: string;
    incomes: Array<IncomeModel>;
}