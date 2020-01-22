import { StationModel } from 'src/app/modules/station/models/station.model';
import { PageSettingModel } from 'src/app/shared/models/page.model';

export class IncomeModel extends PageSettingModel {
    id: number;
    date: Date;
    stationId: number;
    carPlate: string;
    weight: number;
    price: number;
    debit: number;
    credit: number;
    total: number;
    notes: string;
    station: StationModel;
}