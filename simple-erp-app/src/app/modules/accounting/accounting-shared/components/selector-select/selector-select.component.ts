import { Component, EventEmitter, Output, Input } from '@angular/core';
import { SelectorModel } from '../../../../hr/selector/models/selector.model';
import { SelectorService } from '../../../../hr/selector/services/selector.service';

@Component({
  selector: 'app-selector-select',
  templateUrl: './selector-select.component.html'
})

export class SelectorSelectComponent {
  selectorList: Array<SelectorModel>;
  @Output() entityEmitter = new EventEmitter<SelectorModel>();
  selected: SelectorModel = new SelectorModel();
  @Input() id: number;
  constructor(private selectorService: SelectorService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private getAllLite() {
    this.selectorService.getAllLite().subscribe(response => {
      this.selectorList = response.List;
      this.prepareSelectedModel();
    }, err => {
    });
  }

  private prepareSelectedModel() {
    if (this.id && this.id > 0 && this.selectorList) {
      this.selected.Id = this.id;
      this.selected.HeadName = this.selectorList.find(x => x.Id == this.id).HeadName;
    }
  }

  onSelectorChange() {
    this.entityEmitter.emit(this.selected);
  }
}