import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ExportService } from 'src/app/modules/farm/services/export.service';
import { ExportModel } from 'src/app/modules/farm/models/export.model';
import { FarmModel } from 'src/app/modules/farm/models/farm.model';
import { FarmService } from 'src/app/modules/farm/services/farm.service';

@Component({
  selector: 'app-export-form',
  templateUrl: './export-form.component.html'
})

export class ExportFormComponent {

  exportModel: ExportModel = new ExportModel;
  farmList: Array<FarmModel>;

  constructor(private farmService: FarmService, private router: Router, private exportService: ExportService, private avtiveRoute: ActivatedRoute) {

  }

  ngOnInit() {
    this.getAllFarm();
    if (this.avtiveRoute.snapshot.params["id"]) {
      this.getExportById(this.avtiveRoute.snapshot.params["id"]);
    }
    else {
      this.exportModel.date = new Date();
    }
  }

  private getAllFarm() {

    this.farmService.getAllLite().subscribe(response => {
      this.farmList = response.list;
    }, err => {
    });
  }

  private getExportById(id) {
    this.exportService.getById(id).subscribe(response => {
      this.exportModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.exportModel.date = new Date(this.exportModel.date);
    this.exportService.save(this.exportModel).subscribe(response => {
      this.router.navigate(["/layout/farm/export-list"]);
    }, err => {
    });
  }

  onFarmChange(farmId) {
    this.exportModel.farmId = parseInt(farmId);
  }
}
