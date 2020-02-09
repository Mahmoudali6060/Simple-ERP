import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { FarmService } from '../../services/farm.service';
import { FarmModel } from '../../models/farm.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-farm-form',
  templateUrl: './farm-form.component.html'
})

export class FarmFormComponent {

  farmModel: FarmModel = new FarmModel;

  constructor(private router: Router, private farmService: FarmService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<FarmFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getFarmById(this.data.id);
    }
  }

  private getFarmById(id) {
    this.farmService.getById(id).subscribe(response => {
      this.farmModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.farmService.save(this.farmModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
}
