import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { OutcomeService } from '../../services/outcome.service';
import { OutcomeModel } from '../../models/outcome.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-outcome-form',
  templateUrl: './outcome-form.component.html'
})

export class OutcomeFormComponent {

  outcomeModel: OutcomeModel = new OutcomeModel;

  constructor(private router: Router, private outcomeService: OutcomeService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<OutcomeFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getOutcomeById(this.data.id);
    }
  }

  private getOutcomeById(id) {
    this.outcomeService.getById(id).subscribe(response => {
      this.outcomeModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.outcomeService.save(this.outcomeModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
}
