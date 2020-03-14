import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { SafeService } from '../../services/safe.service';
import { SafeModel } from '../../models/safe.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { AccountTreeEnum } from 'src/app/shared/enums/account-tree.enum';
import { FarmModel } from 'src/app/modules/suppliers/farm/models/farm.model';
import { DriverModel } from 'src/app/modules/hr/driver/models/driver.model';
import { StationModel } from 'src/app/modules/clients/station/models/station.model';
import { ReaperModel } from 'src/app/modules/hr/reaper/models/reaper.model';
import { SelectorModel } from 'src/app/modules/hr/selector/models/selector.model';

@Component({
  selector: 'app-safe-form',
  templateUrl: './safe-form.component.html'
})

export class SafeFormComponent {

  safeModel: SafeModel = new SafeModel;
  accountTreeList: any;
  accountTreeType: any = null;
  constructor(private router: Router, private safeService: SafeService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<SafeFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getSafeById(this.data.id);
    }
    this.prepareAccountTreeList();
  }

  private getSafeById(id) {
    this.safeService.getById(id).subscribe(response => {
      this.safeModel = response;
      this.safeModel.Date = new Date(response.Date);
      this.accountTreeType = AccountTreeEnum[this.safeModel.AccountTreeType];
    }, err => {
    });
  }

  private prepareAccountTreeList() {
    var options = Object.keys(AccountTreeEnum);
    this.accountTreeList = options.slice(options.length / 2);
  }

  public onAccountTreeChange(event: any) {
    let accounName: string = event.target.value;
    this.safeModel.AccountTreeType = AccountTreeEnum[accounName];
  }

  public save(form: NgForm) {
    this.safeModel.Date = new Date(this.safeModel.Date);
    this.safeService.save(this.safeModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }

  onFarmChange(farm: FarmModel) {
    this.safeModel.AccountId = farm.Id;
    this.safeModel.AccountNameAr = farm.OwnerName;

  }

  onDriverChange(driver: DriverModel) {
    this.safeModel.AccountId = driver.Id;
    this.safeModel.AccountNameAr = driver.FullName;
  }

  onStationChange(station: StationModel) {
    this.safeModel.AccountId = station.Id;
    this.safeModel.AccountNameAr = station.OwnerName;
  }

  onReaperChange(reaper: ReaperModel) {
    this.safeModel.AccountId = reaper.Id;
    this.safeModel.AccountNameAr = reaper.HeadName;

  }

  onSelectorChange(selector: SelectorModel) {
    this.safeModel.AccountId = selector.Id;
    this.safeModel.AccountNameAr = selector.HeadName;
  }
}
