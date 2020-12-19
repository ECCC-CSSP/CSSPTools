import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnalysisOptionsComponent } from 'src/app/components/analysis/analysis-options/analysis-options.component';

describe('AnalysisOptionsComponent', () => {
  let component: AnalysisOptionsComponent;
  let fixture: ComponentFixture<AnalysisOptionsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ AnalysisOptionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnalysisOptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
