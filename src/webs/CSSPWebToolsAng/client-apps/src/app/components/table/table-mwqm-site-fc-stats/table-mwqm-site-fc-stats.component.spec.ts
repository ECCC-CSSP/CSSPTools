import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMWQMSiteFCStatsComponent } from 'src/app/components/table/table-mwqm-site-fc-stats/table-mwqm-site-fc-stats.component';

describe('TableMWQMSiteFCStatsComponent', () => {
  let component: TableMWQMSiteFCStatsComponent;
  let fixture: ComponentFixture<TableMWQMSiteFCStatsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMWQMSiteFCStatsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMWQMSiteFCStatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
