import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SamplingPlanItemComponent } from 'src/app/components/sampling-plan/sampling-plan-item/sampling-plan-item.component';

describe('SamplingPlanItemComponent', () => {
  let component: SamplingPlanItemComponent;
  let fixture: ComponentFixture<SamplingPlanItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SamplingPlanItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SamplingPlanItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
