import { StationModel } from 'src/app/modules/station/models/station.model';

export class IncomeModel {
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