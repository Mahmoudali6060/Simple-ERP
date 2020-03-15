import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { TransactionService } from '../../services/transaction.service';
import { TransactionModel } from '../../models/transaction.model';
import { FarmModel } from '../../../../../modules/suppliers/farm/models/farm.model';
import { FarmService } from '../../../../../modules/suppliers/farm/services/farm.service';

@Component({
  selector: 'app-transaction-form',
  templateUrl: './transaction-form.component.html'
})

export class TransactionFormComponent {

  transactionModel: TransactionModel = new TransactionModel;
  farmList: Array<FarmModel>;
  lastTonPrice: number;
  pardonPercentage: number = 2;
  pardonType: string = "percentage";
  clicked: boolean = false;
  constructor(private farmService: FarmService,
    private router: Router,
    private transactionService: TransactionService,
    private avtiveRoute: ActivatedRoute) {
  }

  ngOnInit() {

  }

  ngAfterViewInit() {
    if (this.avtiveRoute.snapshot.params["id"]) {
      this.getTransactionById(this.avtiveRoute.snapshot.params["id"]);
    }
    else {
      this.transactionModel.Date = new Date();
    }
  }

  private getTransactionById(id) {
    this.transactionService.getById(id).subscribe(response => {
      this.transactionModel = response;
      this.transactionModel.Date = new Date(this.transactionModel.Date);
      this.calculateTotalAfterPardon();
      this.calculateTotalAfterDiscount();
      this.calculateSupplierAmount();
      this.calculateClientAmount();
      this.calculateSupplierTotal();
      this.sum();
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.transactionModel.Date = new Date(this.transactionModel.Date);
    this.transactionService.save(this.transactionModel).subscribe(response => {
      this.router.navigate(["/layout/transaction/transaction-list"]);
    }, err => {
    });
  }

  onFarmChange(farm) {
    this.transactionModel.FarmId = farm.Id;
    this.transactionModel.FarmOwnerName = farm.OwnerName;

  }

  onCategoryChange(category) {
    this.transactionModel.CategoryId = category.Id;
    this.transactionModel.CategoryName = category.Name;

  }

  onDriverChange(driver) {
    this.transactionModel.DriverId = driver.Id;
    this.transactionModel.CarPlate = driver.CarPlate;

  }

  onStationChange(station) {
    this.transactionModel.StationId = station.Id;
    this.transactionModel.StationOwnerName = station.OwnerName;

  }
  onReaperChange(reaper) {
    this.transactionModel.ReaperId = reaper.Id;
    this.transactionModel.ReaperHead = reaper.HeadName;
    this.lastTonPrice = reaper.LastTonPrice;
    this.calculatePearsPay();
  }

  onSelectorChange(selector) {
    this.transactionModel.SelectorId = selector.Id;
  }

  private calculatePearsPay() {
    if (this.transactionModel.SupplierQuantity && this.lastTonPrice)
      this.transactionModel.ReapersPay = (this.transactionModel.SupplierQuantity / 1000) * this.lastTonPrice;
  }

  public calculateTotalAfterPardon() {
    if (this.pardonType == "percentage" && this.transactionModel.SupplierQuantity) {
      this.transactionModel.Pardon = (this.pardonPercentage / 100) * this.transactionModel.SupplierQuantity;
      this.transactionModel.TotalAfterPardon = this.transactionModel.SupplierQuantity - this.transactionModel.Pardon;
    }
    else if (this.transactionModel.Pardon && this.transactionModel.SupplierQuantity) {
      this.transactionModel.TotalAfterPardon = this.transactionModel.SupplierQuantity - this.transactionModel.Pardon;
    }

  }

  public calculateTotalAfterDiscount() {
    if (this.transactionModel.ClientDiscount && this.transactionModel.ClientQuantity) {
      this.transactionModel.TotalAfterDiscount = this.transactionModel.ClientQuantity - this.transactionModel.ClientDiscount;
    }
  }

  public calculateClientAmount() {
    if (this.transactionModel.ClientDiscount && this.transactionModel.ClientQuantity && this.transactionModel.ClientPrice) {
      this.transactionModel.ClientTotal = this.transactionModel.TotalAfterDiscount * this.transactionModel.ClientPrice;
    }
  }


  public calculateSupplierAmount() {
    if (this.transactionModel.Pardon && this.transactionModel.SupplierQuantity && this.transactionModel.SupplierPrice) {
      this.transactionModel.SupplierAmount = this.transactionModel.TotalAfterPardon * this.transactionModel.SupplierPrice;
    }
  }

  public calculateSupplierTotal() {
    this.transactionModel.SupplierTotal = ((this.transactionModel.SupplierQuantity - this.transactionModel.Pardon) * this.transactionModel.SupplierPrice) + this.transactionModel.Nolon + this.transactionModel.FarmExpense + this.transactionModel.ReapersPay + this.transactionModel.SelectorsPay;
  }

  public sum() {
    this.transactionModel.Sum = (this.transactionModel.ClientTotal - this.transactionModel.SupplierTotal)
  }
}
