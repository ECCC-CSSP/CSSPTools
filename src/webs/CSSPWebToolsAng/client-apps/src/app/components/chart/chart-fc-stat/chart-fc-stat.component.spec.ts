import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartFCStatComponent } from 'src/app/components/chart/chart-fc-stat/chart-fc-stat.component';

describe('ChartFCStatComponent', () => {
  let component: ChartFCStatComponent;
  let fixture: ComponentFixture<ChartFCStatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartFCStatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartFCStatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
