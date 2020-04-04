import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './app-material.module';
import { HttpClientModule } from '@angular/common/http';
import { NoPageFoundModule } from './components/no-page-found/no-page-found.module';
import { ShellModule } from './components/shell/shell.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    ShellModule,
    NoPageFoundModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
