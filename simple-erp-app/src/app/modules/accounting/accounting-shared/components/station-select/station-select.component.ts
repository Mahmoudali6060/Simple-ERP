import { Component, EventEmitter, Output, Input } from '@angular/core';
import { StationModel } from '../../../../clients/station/models/station.model';
import { StationService } from '../../../../clients/station/services/station.service';

@Component({
  selector: 'app-station-select',
  templateUrl: './station-select.component.html'
})

export class StationSelectComponent {
  stationList: Array<StationModel>;
  @Output() entityEmitter = new EventEmitter<StationModel>();
  selected: StationModel = new StationModel();
  @Input() id: number;

  constructor(private stationService: StationService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private getAllLite() {
    this.stationService.getAllLite().subscribe(response => {
      this.stationList = response.List;
      this.prepareSelectedModel();
    }, err => {
    });
  }

  private prepareSelectedModel() {
    if (this.id && this.id > 0 && this.stationList) {
      this.selected.Id = this.id;
      this.selected.OwnerName = this.stationList.find(x => x.Id == this.id).OwnerName;
    }
  }

  onStationChange() {
    this.entityEmitter.emit(this.selected);
  }
}