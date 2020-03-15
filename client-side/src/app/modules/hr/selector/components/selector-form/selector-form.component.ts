import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { SelectorService } from '../../services/selector.service';
import { SelectorModel } from '../../models/selector.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-selector-form',
  templateUrl: './selector-form.component.html'
})

export class SelectorFormComponent {

  selectorModel: SelectorModel = new SelectorModel;
  clicked: boolean = false;
  
  constructor(private router: Router, private selectorService: SelectorService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<SelectorFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getSelectorById(this.data.id);
    }
  }

  private getSelectorById(id) {
    this.selectorService.getById(id).subscribe(response => {
      this.selectorModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.selectorService.save(this.selectorModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }
}
