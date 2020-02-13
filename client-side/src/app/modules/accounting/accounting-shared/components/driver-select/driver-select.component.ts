import { Component, EventEmitter, Output, Input } from '@angular/core';
import { DriverService } from 'src/app/modules/hr/driver/services/driver.service';
import { DriverModel } from '../../../../../modules/hr/driver/models/driver.model';

@Component({
  selector: 'app-driver-select',
  templateUrl: './driver-select.component.html'
})

export class DriverSelectComponent {
  driverList: Array<DriverModel>;
  @Output() entityEmitter = new EventEmitter<DriverModel>();
  selected: DriverModel = new DriverModel();
  @Input() id: number;

  constructor(private driverService: DriverService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private prepareSelectedModel() {
    if (this.id && this.id > 0 && this.driverList) {
      this.selected.Id = this.id;
      this.selected.CarPlate = this.driverList.find(x => x.Id == this.id).CarPlate;
    }

  }

  private getAllLite() {
    this.driverService.getAllLite().subscribe(response => {
      this.driverList = response.List;
      this.prepareSelectedModel();
    }, err => {
    });
  }

  onDriverChange() {
    this.entityEmitter.emit(this.selected);
  }
}