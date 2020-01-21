// import { Component, Input, OnInit } from '@angular/core';
// import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

// @Component({
//   selector: 'confirmation-dialog',
//   templateUrl: './confirmation-dialog.component.html',
// })
// export class ConfirmationDialogComponent implements OnInit {

//   @Input() title: string;
//   @Input() message: string;
//   @Input() btnOkText: string;
//   @Input() btnCancelText: string;

//   constructor(private activeModal: NgbActiveModal) { }

//   ngOnInit() {
//   }

//   public decline() {
//     this.activeModal.close(false);
//   }

//   public accept() {
//     this.activeModal.close(true);
//   }

//   public dismiss() {
//     this.activeModal.dismiss();
//   }

// }


import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Component, OnInit, Inject } from '@angular/core';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html'
})
export class ConfirmationDialogComponent {
  title: string = "حذف";
  message: string = "هل تريد حذف هذا السجل ؟";

  constructor(public dialogRef: MatDialogRef<ConfirmationDialogComponent>) {
  }

  onConfirm(): void {
    // Close the dialog, return true
    this.dialogRef.close(true);
  }

  onDismiss(): void {
    // Close the dialog, return false
    this.dialogRef.close(false);
  }

}


