import { FarmModel } from 'src/app/modules/farm/models/farm.model';

export class ExportModel {
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
    notes: number;
    farm: FarmModel;
}