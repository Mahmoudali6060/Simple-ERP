import { Component, EventEmitter, Output, Input } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { CategoryModel } from '../../models/category.model';

@Component({
  selector: 'app-category-select',
  templateUrl: './category-select.component.html'
})

export class CategorySelectComponent {
  categoryList: Array<CategoryModel>;
  @Output() entityEmitter = new EventEmitter<CategoryModel>();
  selected: CategoryModel = new CategoryModel();
  @Input() id: number;
  constructor(private categoryService: CategoryService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private getAllLite() {
    this.categoryService.getAllLite().subscribe(response => {
      this.categoryList = response.List;
      this.prepareSelectedModel();
    }, err => {
    });
  }

  private prepareSelectedModel() {
    if (this.id && this.id > 0 && this.categoryList) {
      this.selected.Id = this.id;
      this.selected.Name = this.categoryList.find(x => x.Id == this.id).Name;
    }

  }

  onCategoryChange() {
    this.entityEmitter.emit(this.selected);
  }
}