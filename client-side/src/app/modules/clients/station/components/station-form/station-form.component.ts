import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { StationService } from '../../services/station.service';
import { StationModel } from '../../models/station.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-station-form',
  templateUrl: './station-form.component.html'
})

export class StationFormComponent {

  stationModel: StationModel = new StationModel;
  clicked: boolean = false;
  
  constructor(private router: Router, private stationService: StationService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<StationFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getStationById(this.data.id);
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
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
}
