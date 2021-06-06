import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartMWQMRunDataComponent } from 'src/app/components/chart/chart-mwqm-run-data/chart-mwqm-run-data.component';

describe('ChartMWQMRunDataComponent', () => {
  let component: ChartMWQMRunDataComponent;
  let fixture: ComponentFixture<ChartMWQMRunDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartMWQMRunDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartMWQMRunDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
