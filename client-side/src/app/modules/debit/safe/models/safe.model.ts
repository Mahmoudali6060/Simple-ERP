import { AccountTreeEnum } from '../../../../shared/enums/account-tree.enum';

export class SafeModel {
    Date: Date;
    Incoming: number;
    Outcoming: number;
    Balance: number;
    AccountTreeType: AccountTreeEnum;
    AccountId: number;
    AccountNameAr: string;
    Description: string;
    RecieptNumber: string;
}

// "Date","Incoming","Outcoming","Balance","Description"