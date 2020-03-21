import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { SalaryService } from '../../services/salary.service';
import { SalaryModel } from '../../models/salary.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-salary-form',
  templateUrl: './salary-form.component.html'
})

export class SalaryFormComponent {

  salaryModel: SalaryModel = new SalaryModel;
  clicked: boolean = false;
  
  constructor(private router: Router, private salaryService: SalaryService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<SalaryFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getSalaryById(this.data.id);
    }
  }

  private getSalaryById(id) {
    this.salaryService.getById(id).subscribe(response => {
      this.salaryModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.salaryService.save(this.salaryModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
}
