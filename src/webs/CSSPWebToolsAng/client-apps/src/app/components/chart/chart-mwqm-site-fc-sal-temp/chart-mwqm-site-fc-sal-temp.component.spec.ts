import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartMWQMSiteFCSalTempComponent } from 'src/app/components/chart/chart-mwqm-site-fc-sal-temp/chart-mwqm-site-fc-sal-temp.component';

describe('ChartMWQMSiteFCSalTempComponent', () => {
  let component: ChartMWQMSiteFCSalTempComponent;
  let fixture: ComponentFixture<ChartMWQMSiteFCSalTempComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartMWQMSiteFCSalTempComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartMWQMSiteFCSalTempComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
