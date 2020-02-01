import { Component, EventEmitter, Output } from '@angular/core';
import { StationModel } from '../../../../station/models/station.model';
import { StationService } from '../../../../station/services/station.service';

@Component({
  selector: 'app-station-select',
  templateUrl: './station-select.component.html'
})

export class StationSelectComponent {
  stationList: Array<StationModel>;
  @Output() entityEmitter = new EventEmitter<StationModel>();
  selected: StationModel;
  constructor(private stationService: StationService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private getAllLite() {
    this.stationService.getAllLite().subscribe(response => {
      this.stationList = response.List;
    }, err => {
    });
  }

  onStationChange() {
    this.entityEmitter.emit(this.selected);
  }
}