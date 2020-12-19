import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnalysisDataVisibleComponent } from 'src/app/components/analysis/analysis-data-visible/analysis-data-visible.component';

describe('AnalysisDataVisibleComponent', () => {
  let component: AnalysisDataVisibleComponent;
  let fixture: ComponentFixture<AnalysisDataVisibleComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ AnalysisDataVisibleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnalysisDataVisibleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
