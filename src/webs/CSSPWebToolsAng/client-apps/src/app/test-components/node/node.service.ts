/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { NodeTextModel, NodeModel } from './node.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesNodeText } from './node.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Node } from 'src/app/models/generated/Node.model';

@Injectable({
  providedIn: 'root'
})
export class NodeService {
  nodeTextModel$: BehaviorSubject<NodeTextModel> = new BehaviorSubject<NodeTextModel>(<NodeTextModel>{});
  nodeModel$: BehaviorSubject<NodeModel> = new BehaviorSubject<NodeModel>(<NodeModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesNodeText(this);
    this.UpdateNodeText(<NodeTextModel>{ Title: "Something2 for text" });
  }

  UpdateNodeText(nodeTextModel: NodeTextModel) {
    this.nodeTextModel$.next(<NodeTextModel>{ ...this.nodeTextModel$.getValue(), ...nodeTextModel });
  }

  UpdateNodeModel(nodeModel: NodeModel) {
    this.nodeModel$.next(<NodeModel>{ ...this.nodeModel$.getValue(), ...nodeModel });
  }

  GetNode(router: Router) {
    let oldURL = router.url;
    this.UpdateNodeModel(<NodeModel>{ Working: true, Error: null });

    return this.httpClient.get<Node[]>('/api/Node').pipe(
      map((x: any) => {
        console.debug(`Node OK. Return: ${x}`);
        this.nodeModel$.getValue().NodeList = <Node[]>x;
        this.UpdateNodeModel(this.nodeModel$.getValue());
        this.UpdateNodeModel(<NodeModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateNodeModel(<NodeModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`Node ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
