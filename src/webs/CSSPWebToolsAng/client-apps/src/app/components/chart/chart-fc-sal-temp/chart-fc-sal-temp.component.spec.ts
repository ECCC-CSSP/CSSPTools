import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartFCSalTempComponent } from 'src/app/components/chart/chart-fc-sal-temp/chart-fc-sal-temp.component';

describe('ChartFCSalTempComponent', () => {
  let component: ChartFCSalTempComponent;
  let fixture: ComponentFixture<ChartFCSalTempComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartFCSalTempComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartFCSalTempComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
