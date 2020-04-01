import { Injectable } from '@angular/core';
import { AppVariables } from '../models/app.interfaces';

@Injectable({
  providedIn: 'root'
})
export class AppVariablesService {
  variables: AppVariables;

  constructor() { }

  SetAppVariables(appVariables: AppVariables ){
    this.variables = {...this.variables, ...appVariables };
  }
}
