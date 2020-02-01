import { Component, EventEmitter, Output } from '@angular/core';
import { DriverService } from 'src/app/modules/hr/driver/services/driver.service';
import { DriverModel } from '../../../../../modules/hr/driver/models/driver.model';

@Component({
  selector: 'app-driver-select',
  templateUrl: './driver-select.component.html'
})

export class DriverSelectComponent {
  driverList: Array<DriverModel>;
  @Output() entityEmitter = new EventEmitter<DriverModel>();
  selected: DriverModel;
  constructor(private driverService: DriverService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private getAllLite() {
    this.driverService.getAllLite().subscribe(response => {
      this.driverList = response.List;
    }, err => {
    });
  }

  onDriverChange() {
    this.entityEmitter.emit(this.selected);
  }
}