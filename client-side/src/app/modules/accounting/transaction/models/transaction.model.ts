
export class TransactionModel {
    Id: number=0;
    Number: string;
    Date: Date;
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


// "Number","Date","FarmOwnerName","CategoryName","CarPlate","SupplierQuantity","Pardon","TotalAfterPardon",
// "SupplierPrice","SupplierAmount","Nolon","ReaperHead","ReapersPay","StationOwnerName","SelectorsPay","FarmExpense",
// "SupplierTotal","CartNumber","ClientQuantity","ClientDiscount","TotalAfterDiscount","ClientPrice","ClientTotal","Sum"