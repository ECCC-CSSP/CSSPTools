import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioItemViewInformationSourcesComponent } from 'src/app/components/mike-scenario/mike-scenario-item-view-information-sources/mike-scenario-item-view-information-sources.component';

describe('MikeScenarioItemViewInformationSourcesComponent', () => {
  let component: MikeScenarioItemViewInformationSourcesComponent;
  let fixture: ComponentFixture<MikeScenarioItemViewInformationSourcesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemViewInformationSourcesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemViewInformationSourcesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
