import { Component, EventEmitter, Output } from '@angular/core';
import { FarmModel } from '../../../../suppliers/farm/models/farm.model';
import { FarmService } from '../../../../suppliers/farm/services/farm.service';

@Component({
  selector: 'app-farm-select',
  templateUrl: './farm-select.component.html'
})

export class FarmSelectComponent {
  farmList: Array<FarmModel>;
  @Output() entityEmitter = new EventEmitter<FarmModel>();
  selected: FarmModel;
  constructor(private farmService: FarmService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private getAllLite() {
    this.farmService.getAllLite().subscribe(response => {
      this.farmList = response.List;
    }, err => {
    });
  }

  onFarmChange() {
    this.entityEmitter.emit(this.selected);
  }
}