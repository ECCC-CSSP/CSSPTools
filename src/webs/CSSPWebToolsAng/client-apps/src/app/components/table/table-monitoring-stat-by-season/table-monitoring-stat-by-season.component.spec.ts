import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMonitoringStatBySeasonComponent } from 'src/app/components/table/table-monitoring-stat-by-season/table-monitoring-stat-by-season.component';

describe('TableMonitoringStatBySeasonComponent', () => {
  let component: TableMonitoringStatBySeasonComponent;
  let fixture: ComponentFixture<TableMonitoringStatBySeasonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMonitoringStatBySeasonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMonitoringStatBySeasonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
