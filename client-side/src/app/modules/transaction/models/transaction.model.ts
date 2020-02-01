import { PageSettingModel } from 'src/app/shared/models/page.model';

export class TransactionModel extends PageSettingModel {
    Id: number;
    Number: string;
    Date: Date;
    DateStr:string;
    FarmId: number;
    FarmOwnerName: string;
    CategoryId: number;
    CategoryName: string;
    DriverId: number;
    CarPlate: string;
    SupplierQuantity: number;
    Pardon: number;
    TotalAfterPardon: number;
    SupplierPrice: number;
    SupplierAmount: number;
    Nolon: number;
    ReaperId: number;
    ReaperHead: string;
    ReapersPay: number;
    SelectorId: number;
    StationOwnerName: string;
    SelectorsPay: number;
    FarmExpense: number;
    SupplierTotal: number;
    StationId: number;
    CartNumber: string;
    ClientQuantity: number;
    ClientDiscount: number;
    TotalAfterDiscount: number;
    ClientPrice: number;
    ClientTotal: number;
    Sum: number;
}