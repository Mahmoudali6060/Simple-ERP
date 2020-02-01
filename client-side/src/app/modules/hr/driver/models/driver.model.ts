import { PageSettingModel } from 'src/app/shared/models/page.model';

export class DriverModel extends PageSettingModel {
    Id: number;
    FullName: string;
    Mobile: string;
    CarPlate: string;
    Transfers: any;
    Outcomes: any;
}