import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { DatabaseService } from '../../services/database.service';
import { DatabaseModel } from '../../models/database.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-database-backup',
  templateUrl: './database-backup.component.html'
})

export class DatabaseBackupComponent {

  databaseModel: DatabaseModel = new DatabaseModel;
  clicked: boolean = false;

  constructor(private router: Router, private databaseService: DatabaseService,
    private toastrService: ToastrService,
    public dialogRef: MatDialogRef<DatabaseBackupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {

  }

  public backupdDatabase(form: NgForm) {
    this.databaseService.backupdDatabase(this.databaseModel).subscribe(response => {
      this.toastrService.success("", "تم عمل نسخة احتياطية للبيانات بنجاح", { positionClass: 'toast-bottom-right' });
    }, err => {
      this.toastrService.error("", "حدث خطأ", { positionClass: 'toast-bottom-right' });
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
  
}
