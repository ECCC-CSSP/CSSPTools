import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartBaseComponent } from 'src/app/components/chart/chart-base/chart-base.component';

describe('ChartBaseComponent', () => {
  let component: ChartBaseComponent;
  let fixture: ComponentFixture<ChartBaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
