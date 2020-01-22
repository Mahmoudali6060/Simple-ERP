import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { IncomeService } from '../../services/income.service';
import { IncomeModel } from '../../models/income.model';
import { StationModel } from '../../models/station.model';
import { StationService } from '../../services/station.service';

@Component({
  selector: 'app-income-form',
  templateUrl: './income-form.component.html'
})

export class IncomeFormComponent {

  incomeModel: IncomeModel = new IncomeModel;
  stationList: Array<StationModel>;

  constructor(private stationService: StationService, private router: Router, private incomeService: IncomeService, private avtiveRoute: ActivatedRoute) {

  }

  ngOnInit() {
    this.getAllStation();
    if (this.avtiveRoute.snapshot.params["id"]) {
      this.getIncomeById(this.avtiveRoute.snapshot.params["id"]);
    }
    else {
      this.incomeModel.date = new Date();
    }
  }

  private getAllStation() {

    this.stationService.getAllLite().subscribe(response => {
      this.stationList = response.list;
    }, err => {
    });
  }

  private getIncomeById(id) {
    this.incomeService.getById(id).subscribe(response => {
      this.incomeModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.incomeModel.date = new Date(this.incomeModel.date);
    this.incomeService.save(this.incomeModel).subscribe(response => {
      this.router.navigate(["/layout/station/income-list"]);
    }, err => {
    });
  }

  onStationChange(stationId) {
    this.incomeModel.stationId = parseInt(stationId);
  }
}
