import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMonitoringStatsBySeasonComponent } from 'src/app/components/table/table-monitoring-stats-by-season/table-monitoring-stats-by-season.component';

describe('TableMonitoringStatsBySeasonComponent', () => {
  let component: TableMonitoringStatsBySeasonComponent;
  let fixture: ComponentFixture<TableMonitoringStatsBySeasonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMonitoringStatsBySeasonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMonitoringStatsBySeasonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
