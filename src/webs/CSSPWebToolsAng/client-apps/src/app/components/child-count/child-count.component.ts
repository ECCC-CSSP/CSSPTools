import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { ShellService } from 'src/app/pages/shell';
import { ChildCountService } from './child-count.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-child-count',
  templateUrl: './child-count.component.html',
  styleUrls: ['./child-count.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ChildCountComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  constructor(public childCountService: ChildCountService, public shellService: ShellService, public router: Router) {
  }

  ngOnInit() {
    this.TVItemModel.TVItemStatList.filter((c) => { this.total += c.ChildCount });
  }

  ngOnDestroy()
  {
  }

}
