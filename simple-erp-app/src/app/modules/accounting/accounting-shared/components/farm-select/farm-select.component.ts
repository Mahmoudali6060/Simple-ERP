import { Component, EventEmitter, Output, Input } from '@angular/core';
import { FarmModel } from '../../../../suppliers/farm/models/farm.model';
import { FarmService } from '../../../../suppliers/farm/services/farm.service';

@Component({
  selector: 'app-farm-select',
  templateUrl: './farm-select.component.html'
})

export class FarmSelectComponent {
  farmList: Array<FarmModel>;
  @Output() entityEmitter = new EventEmitter<FarmModel>();
  selected: FarmModel = new FarmModel();
  @Input() id: number;
  constructor(private farmService: FarmService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private getAllLite() {
    this.farmService.getAllLite().subscribe(response => {
      this.farmList = response.List;
      this.prepareSelectedModel();
    }, err => {
    });
  }

  private prepareSelectedModel() {
    if (this.id && this.id > 0 && this.farmList) {
      this.selected.Id = this.id;
      this.selected.OwnerName = this.farmList.find(x => x.Id == this.id).OwnerName;
    }

  }

  onFarmChange() {
    this.entityEmitter.emit(this.selected);
  }
}