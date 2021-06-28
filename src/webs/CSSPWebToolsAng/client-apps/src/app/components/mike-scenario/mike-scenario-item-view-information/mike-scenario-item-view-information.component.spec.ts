import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioItemViewInformationComponent } from 'src/app/components/mike-scenario/mike-scenario-item-view-information/mike-scenario-item-view-information.component';

describe('MikeScenarioItemViewInformationComponent', () => {
  let component: MikeScenarioItemViewInformationComponent;
  let fixture: ComponentFixture<MikeScenarioItemViewInformationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemViewInformationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemViewInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
