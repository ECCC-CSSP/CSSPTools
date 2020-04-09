import { Injectable } from '@angular/core';
import { GenerateWithDocModel } from './generate-with-doc.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenerateWithDocService {
  generateWithDocModel$: BehaviorSubject<GenerateWithDocModel> = new BehaviorSubject<GenerateWithDocModel>(<GenerateWithDocModel>{});

  constructor() {
    this.UpdateWithDoc(<GenerateWithDocModel>{ Title: 'Title of the app' });
   }

   UpdateWithDoc(generateWithDocModel: GenerateWithDocModel)
  {
    this.generateWithDocModel$.next(<GenerateWithDocModel>{...this.generateWithDocModel$.getValue(), ...generateWithDocModel});
  }
}
