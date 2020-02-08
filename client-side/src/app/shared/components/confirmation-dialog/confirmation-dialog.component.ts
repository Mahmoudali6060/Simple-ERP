import { Component, EventEmitter, Output, ViewChild, Inject } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html'
})

export class ConfirmationDialogComponent {
  closeResult: string;
  @ViewChild('content', { static: false }) content: any;
  @Output() confirmDeleteEmitter = new EventEmitter<number>();
  id: number;

  constructor(
    public dialogRef: MatDialogRef<ConfirmationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public message: string) { }
  onNoClick(): void {
    this.dialogRef.close();
  }

  // constructor(private modalService: NgbModal) { }

  // open(id: number) {
  //   this.id = id;
  //   this.modalService.open(this.content);
  // }

  // public confirmDelete() {
  //   this.confirmDeleteEmitter.emit(this.id);
  //   this.modalService.dismissAll();
  // }
}
