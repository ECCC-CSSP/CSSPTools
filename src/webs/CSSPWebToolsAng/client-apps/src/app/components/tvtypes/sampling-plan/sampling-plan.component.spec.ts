import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SamplingPlanComponent } from 'src/app/components/tvtypes/sampling-plan/sampling-plan.component';

describe('SamplingPlanComponent', () => {
  let component: SamplingPlanComponent;
  let fixture: ComponentFixture<SamplingPlanComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SamplingPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SamplingPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
