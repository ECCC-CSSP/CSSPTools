import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './app-material.module';
import { SearchComponent } from './components/search/search.component';
import { SearchOptionComponent } from './components/search-option/search-option.component';
import { BreadCrumbComponent } from './components/bread-crumb/bread-crumb.component';
import { TVItemListComponent } from './components/tvitem-list/tvitem-list.component';
import { TVItemListItemComponent } from './components/tvitem-list-item/tvitem-list-item.component';

@NgModule({
  declarations: [
    SearchComponent,
    SearchOptionComponent,
    BreadCrumbComponent,
    TVItemListComponent,
    TVItemListItemComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    CommonModule,
    MaterialModule,
    SearchComponent,
    FormsModule,
    ReactiveFormsModule,
    SearchComponent,
    SearchOptionComponent,
    BreadCrumbComponent,
    TVItemListComponent,
    TVItemListItemComponent
  ]
})
export class SharedModule { }
