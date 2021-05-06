import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from 'src/app/app.component';
import { SharedModule } from 'src/app/shared.module';
//import { getSaver, SAVER } from 'src/app/services/helpers/saver.provider';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    SharedModule,
  ],
  exports: [],
  //providers: [{provide: SAVER, useFactory: getSaver}],
  bootstrap: [AppComponent]
})
export class AppModule { }
