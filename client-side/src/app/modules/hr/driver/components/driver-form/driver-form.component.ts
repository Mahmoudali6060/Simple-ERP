import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { DriverService } from '../../services/driver.service';
import { DriverModel } from '../../models/driver.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-driver-form',
  templateUrl: './driver-form.component.html'
})

export class DriverFormComponent {

  driverModel: DriverModel = new DriverModel;

  constructor(private router: Router, private driverService: DriverService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<DriverFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getDriverById(this.data.id);
    }
  }

  private getDriverById(id) {
    this.driverService.getById(id).subscribe(response => {
      this.driverModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.driverService.save(this.driverModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
}
