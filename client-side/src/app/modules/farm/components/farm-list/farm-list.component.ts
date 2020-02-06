import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { FarmService } from '../../services/farm.service';
import { FarmModel } from '../../models/farm.model';
import { ModalBasicComponent } from '../../../../shared/components/modal-basic/modal-basic.component';
import { DataSourceModel } from 'src/app/shared/models/data-source.model';

@Component({
  selector: 'app-farm-list',
  templateUrl: './farm-list.component.html'
})

export class FarmListComponent {
  farmList: Array<FarmModel>;//Data List
  properties = ["OwnerName", "OwnerMobile", "Address", "Notes"];//Displayed Columns 
  farm: FarmModel = new FarmModel();//For Add/Update Farm Entity
  @ViewChild(ModalBasicComponent, { static: false }) modalBasicComponent;//Add/Update Farm model
  dataSourceModel: DataSourceModel = new DataSourceModel;
  total: number;
  constructor(private farmService: FarmService) {

  }

  ngOnInit() {
    this.getAllFarms();
  }

  getAllFarms() {
    this.farmService.getAll(this.dataSourceModel).subscribe(response => {
      this.farmList = response.Data;
      this.total = response.Total;
    }, err => {
    });
  }

  public getFarmById(id: number) {
    this.farmService.getById(id)
      .subscribe((response) => {
        this.farm = response.data;
        this.modalBasicComponent.open(this.farm);
      })
      , error => {
      }
  }

  public save(entity) {
    this.farmService.save(entity)
      .subscribe((response) => {
        this.getAllFarms();
      })
      , error => {
      }
  }

  public delete(id: number) {
    this.farmService.delete(id)
      .subscribe((response) => {
        this.getAllFarms();
      })
      , error => {
      }
  }

  public openModal(id?: number) {
    if (id) {
      this.getFarmById(id);
    }
    else {
      this.farm = new FarmModel();
      this.modalBasicComponent.open(this.farm);
    }
  }

  public onChangePagination(dataSourceModel) {
    this.dataSourceModel = dataSourceModel;
    this.getAllFarms();
  }
}
