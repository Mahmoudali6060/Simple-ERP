import { FarmModel } from 'src/app/modules/farm/models/farm.model';
import { PageSettingModel } from 'src/app/shared/models/page.model';

export class ExportModel extends PageSettingModel {
    // id: number;
    // date: Date;
    // farmId: number;
    // carPlate: string;
    // weight: number;
    // pardon: number;
    // weightAfterPardon: number;
    // price: number;
    // debit: number;
    // credit: number;
    // total: number;
    // notes: number;
    // farm: FarmModel;

    id: number;
    date: Date;
    farmId: number;
    carPlate: string;
    weight: number;
    pardon: number;
    weightAfterPardon: number;
    price: number;
    debit: number;
    credit: number;
    total: number;
    notes: string;
    farm: FarmModel;
}