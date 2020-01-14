import { Component, ViewEncapsulation } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})

export class AppComponent {

  constructor(private spinner: NgxSpinnerService) {
    
  }

  ngOnInit() {
   /** spinner starts on init */
   this.spinner.show();
      setTimeout(() => {
        /** spinner ends after 5 seconds */
        this.spinner.hide();
      }, 1000);
  }
}

