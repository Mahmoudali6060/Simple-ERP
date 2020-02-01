import { Component, EventEmitter, Output } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { CategoryModel } from '../../models/category.model';

@Component({
  selector: 'app-category-select',
  templateUrl: './category-select.component.html'
})

export class CategorySelectComponent {
  categoryList: Array<CategoryModel>;
  @Output() entityEmitter = new EventEmitter<CategoryModel>();
  selected: CategoryModel;
  constructor(private categoryService: CategoryService) {
  }

  ngOnInit() {
    this.getAllLite();
  }

  private getAllLite() {
    this.categoryService.getAllLite().subscribe(response => {
      this.categoryList = response.List;
    }, err => {
    });
  }

  onCategoryChange() {
    this.entityEmitter.emit(this.selected);
  }
}