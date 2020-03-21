import { Component, EventEmitter, Output, Input } from '@angular/core';
import { ReaperModel } from '../../../../hr/reaper/models/reaper.model';
import { ReaperService } from '../../../../hr/reaper/services/reaper.service';
import { ReaperLiteModel } from '../../../../hr/reaper/models/reaper-lite.model';

@Component({
  selector: 'app-reaper-select',
  templateUrl: './reaper-select.component.html'
})

export class ReaperSelectComponent {
  reaperList: Array<ReaperModel>;
  @Output() entityEmitter = new EventEmitter<ReaperModel>();
  selected: ReaperModel = new ReaperModel();
  @Input() id: number;
  constructor(private reaperService: ReaperService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private getAllLite() {
    this.reaperService.getAllLite().subscribe(response => {
      this.reaperList = response.List;
      this.prepareSelectedModel();
    }, err => {
    });
  }

  private prepareSelectedModel() {
    if (this.id && this.id > 0 && this.reaperList) {
      this.selected.Id = this.id;
      this.selected.HeadName = this.reaperList.find(x => x.Id == this.id).HeadName;
    }
  }

  onReaperChange() {
    this.entityEmitter.emit(this.selected);
  }
}