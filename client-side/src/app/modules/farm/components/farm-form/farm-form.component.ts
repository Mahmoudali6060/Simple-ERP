import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { FarmService } from 'src/app/modules/farm/services/farm.service';
import { FarmModel } from 'src/app/modules/farm/models/farm.model';

@Component({
  selector: 'app-farm-form',
  templateUrl: './farm-form.component.html'
})

export class FarmFormComponent {

  farmModel: FarmModel = new FarmModel;
  
  constructor(private router: Router, private farmService: FarmService, private avtiveRoute: ActivatedRoute) {

  }

  ngOnInit() {
    if (this.avtiveRoute.snapshot.params["id"]) {
      this.getFarmById(this.avtiveRoute.snapshot.params["id"]);
    }
  }

  private getFarmById(id) {
    this.farmService.getById(id).subscribe(response => {
      this.farmModel = response;
    }, err => {
    });
  }

  public save(form: NgForm) {
    this.farmService.save(this.farmModel).subscribe(response => {
      this.router.navigate(["/layout/farm"]);
    }, err => {
    });
  }

}
