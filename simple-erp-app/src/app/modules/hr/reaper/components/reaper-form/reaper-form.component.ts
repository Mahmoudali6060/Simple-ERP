import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ReaperService } from '../../services/reaper.service';
import { ReaperModel } from '../../models/reaper.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-reaper-form',
  templateUrl: './reaper-form.component.html'
})

export class ReaperFormComponent {

  reaperModel: ReaperModel = new ReaperModel;
  clicked: boolean = false;
  
  constructor(private router: Router, private reaperService: ReaperService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<ReaperFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getReaperById(this.data.id);
    }
  }

  private getReaperById(id) {
    this.reaperService.getById(id).subscribe(response => {
      this.reaperModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.reaperService.save(this.reaperModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
}
