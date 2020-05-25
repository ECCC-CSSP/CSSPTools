import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActionCommandComponent } from './action-command.component';
import { AuthGuard } from 'src/app/helpers/auth.guard';

const routes: Routes = [
  { path: '', component: ActionCommandComponent, canActivate: [AuthGuard]  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ActionCommandRoutingModule { }
