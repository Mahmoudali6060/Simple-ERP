import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { StationService } from 'src/app/modules/station/services/station.service';
import { StationModel } from 'src/app/modules/station/models/station.model';

@Component({
  selector: 'app-station-form',
  templateUrl: './station-form.component.html'
})

export class StationFormComponent {

  stationModel: StationModel = new StationModel;
  
  constructor(private router: Router, private stationService: StationService, private avtiveRoute: ActivatedRoute) {

  }

  ngOnInit() {
    if (this.avtiveRoute.snapshot.params["id"]) {
      this.getStationById(this.avtiveRoute.snapshot.params["id"]);
    }
  }

  private getStationById(id) {
    this.stationService.getById(id).subscribe(response => {
      this.stationModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.stationService.save(this.stationModel).subscribe(response => {
      this.router.navigate(["/layout/station"]);
    }, err => {
    });
  }

}
