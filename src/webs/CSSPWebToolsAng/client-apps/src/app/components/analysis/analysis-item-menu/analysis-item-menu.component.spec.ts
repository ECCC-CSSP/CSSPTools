import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AnalysisItemMenuComponent } from 'src/app/components/analysis/analysis-item-menu/analysis-item-menu.component';

describe('AnalysisItemMenuComponent', () => {
  let component: AnalysisItemMenuComponent;
  let fixture: ComponentFixture<AnalysisItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ AnalysisItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnalysisItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
