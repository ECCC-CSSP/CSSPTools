import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioItemViewComponent } from 'src/app/components/mike-scenario/mike-scenario-item-view/mike-scenario-item-view.component';

describe('MikeScenarioItemViewComponent', () => {
  let component: MikeScenarioItemViewComponent;
  let fixture: ComponentFixture<MikeScenarioItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
