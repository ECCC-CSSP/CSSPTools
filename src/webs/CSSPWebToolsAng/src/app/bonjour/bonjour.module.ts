import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BonjourComponent } from './bonjour.component';
import { BonjourRoutingModule } from './bonjour-routing.module';
import { MatButtonModule} from '@angular/material/button';
import { MatListModule } from '@angular/material/list';

@NgModule({
  declarations: [BonjourComponent],
  imports: [
    CommonModule,
    BonjourRoutingModule,
    MatButtonModule,
    MatListModule,
  ]
})
export class BonjourModule { }
