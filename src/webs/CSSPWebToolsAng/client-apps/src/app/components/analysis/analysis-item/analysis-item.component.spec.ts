import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnalysisItemComponent } from 'src/app/components/analysis/analysis-item/analysis-item.component';

describe('AnalysisItemComponent', () => {
  let component: AnalysisItemComponent;
  let fixture: ComponentFixture<AnalysisItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ AnalysisItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnalysisItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
