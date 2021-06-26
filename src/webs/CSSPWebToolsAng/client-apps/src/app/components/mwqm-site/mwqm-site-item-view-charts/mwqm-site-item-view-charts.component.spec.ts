import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMSiteItemViewChartsComponent } from 'src/app/components/mwqm-site/mwqm-site-item-view-charts/mwqm-site-item-view-charts.component';

describe('MWQMSiteItemViewChartsComponent', () => {
  let component: MWQMSiteItemViewChartsComponent;
  let fixture: ComponentFixture<MWQMSiteItemViewChartsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteItemViewChartsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteItemViewChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
