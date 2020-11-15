import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnalysisComponent } from 'src/app/components/tvtypes/analysis/analysis.component';

describe('AnalysisComponent', () => {
  let component: AnalysisComponent;
  let fixture: ComponentFixture<AnalysisComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ AnalysisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnalysisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
