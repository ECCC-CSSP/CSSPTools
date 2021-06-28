import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioItemViewInformationGeneralParametersComponent } from 'src/app/components/mike-scenario/mike-scenario-item-view-information-general-parameters/mike-scenario-item-view-information-general-parameters.component';

describe('MikeScenarioItemViewInformationGeneralParametersComponent', () => {
  let component: MikeScenarioItemViewInformationGeneralParametersComponent;
  let fixture: ComponentFixture<MikeScenarioItemViewInformationGeneralParametersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemViewInformationGeneralParametersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemViewInformationGeneralParametersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
