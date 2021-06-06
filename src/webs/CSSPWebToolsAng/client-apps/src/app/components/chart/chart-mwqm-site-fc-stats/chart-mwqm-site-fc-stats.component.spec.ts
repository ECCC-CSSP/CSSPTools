import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartMWQMSiteFCStatsComponent } from 'src/app/components/chart/chart-mwqm-site-fc-stats/chart-mwqm-site-fc-stats.component';

describe('ChartMWQMSiteFCStatsComponent', () => {
  let component: ChartMWQMSiteFCStatsComponent;
  let fixture: ComponentFixture<ChartMWQMSiteFCStatsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartMWQMSiteFCStatsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartMWQMSiteFCStatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
