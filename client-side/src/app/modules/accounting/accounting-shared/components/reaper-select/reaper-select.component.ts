import { Component, EventEmitter, Output } from '@angular/core';
import { ReaperModel } from '../../../../hr/reaper/models/reaper.model';
import { ReaperService } from '../../../../hr/reaper/services/reaper.service';
import { ReaperLiteModel } from 'src/app/modules/hr/reaper/models/reaper-lite.model';

@Component({
  selector: 'app-reaper-select',
  templateUrl: './reaper-select.component.html'
})

export class ReaperSelectComponent {
  reaperList: Array<ReaperModel>;
  @Output() entityEmitter = new EventEmitter<ReaperModel>();
  selected: ReaperModel;
  constructor(private reaperService: ReaperService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private getAllLite() {
    this.reaperService.getAllLite().subscribe(response => {
      this.reaperList = response.List;
    }, err => {
    });
  }

  onReaperChange() {
    this.entityEmitter.emit(this.selected);
  }
}