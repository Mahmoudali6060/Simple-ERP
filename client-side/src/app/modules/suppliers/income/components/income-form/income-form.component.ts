import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { IncomeService } from '../../services/income.service';
import { IncomeModel } from '../../models/income.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-income-form',
  templateUrl: './income-form.component.html'
})

export class IncomeFormComponent {

  incomeModel: IncomeModel = new IncomeModel;

  constructor(private router: Router, private incomeService: IncomeService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<IncomeFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getIncomeById(this.data.id);
    }
  }

  private getIncomeById(id) {
    this.incomeService.getById(id).subscribe(response => {
      this.incomeModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.incomeService.save(this.incomeModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
}
