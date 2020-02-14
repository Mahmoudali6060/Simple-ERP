import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { BorrowService } from '../../services/borrow.service';
import { BorrowModel } from '../../models/borrow.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-borrow-form',
  templateUrl: './borrow-form.component.html'
})

export class BorrowFormComponent {

  borrowModel: BorrowModel = new BorrowModel;

  constructor(private router: Router, private borrowService: BorrowService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<BorrowFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getBorrowById(this.data.id);
    }
  }

  private getBorrowById(id) {
    this.borrowService.getById(id).subscribe(response => {
      this.borrowModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.borrowService.save(this.borrowModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
}
