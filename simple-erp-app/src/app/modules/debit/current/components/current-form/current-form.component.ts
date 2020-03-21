import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { CurrentService } from '../../services/current.service';
import { CurrentModel } from '../../models/current.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-current-form',
  templateUrl: './current-form.component.html'
})

export class CurrentFormComponent {

  currentModel: CurrentModel = new CurrentModel;
  clicked: boolean = false;
  
  constructor(private router: Router, private currentService: CurrentService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<CurrentFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getCurrentById(this.data.id);
    }
  }

  private getCurrentById(id) {
    this.currentService.getById(id).subscribe(response => {
      this.currentModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.currentService.save(this.currentModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
}
