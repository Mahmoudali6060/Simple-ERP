import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { TransactionService } from '../../services/transaction.service';
import { TransactionModel } from '../../models/transaction.model';
import { FarmModel } from 'src/app/modules/farm/models/farm.model';
import { FarmService } from '../../../../modules/farm/services/farm.service';

@Component({
  selector: 'app-transaction-form',
  templateUrl: './transaction-form.component.html'
})

export class TransactionFormComponent {

  transactionModel: TransactionModel = new TransactionModel;
  farmList: Array<FarmModel>;
  lastTonPrice: number;

  constructor(private farmService: FarmService,
    private router: Router,
    private transactionService: TransactionService,
    private avtiveRoute: ActivatedRoute) {
  }

  ngOnInit() {
    this.getAllFarm();
    if (this.avtiveRoute.snapshot.params["id"]) {
      this.getTransactionById(this.avtiveRoute.snapshot.params["id"]);
    }
    else {
      this.transactionModel.Date = new Date();
    }
  }

  private getAllFarm() {
    this.farmService.getAllLite().subscribe(response => {
      this.farmList = response.List;
    }, err => {
    });
  }

  private getTransactionById(id) {
    this.transactionService.getById(id).subscribe(response => {
      this.transactionModel = response;
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

  public sum() {
    this.transactionModel.Sum = this.transactionModel.ClientTotal - this.transactionModel.SupplierTotal;
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

  private calculatePearsPay() {
    if (this.transactionModel.SupplierQuantity && this.lastTonPrice)
      this.transactionModel.ReapersPay = (this.transactionModel.SupplierQuantity / 1000) * this.lastTonPrice;
  }

}
