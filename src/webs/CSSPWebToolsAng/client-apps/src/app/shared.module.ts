import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './app-material.module';
import { SearchComponent } from './components/search/search.component';
import { SearchOptionComponent } from './components/search-option/search-option.component';
import { LoggedInContactComponent } from './components/logged-in-contact/logged-in-contact.component';

@NgModule({
  declarations: [
    SearchComponent,
    SearchOptionComponent,
    LoggedInContactComponent,
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
  ]
})
export class SharedModule { }
