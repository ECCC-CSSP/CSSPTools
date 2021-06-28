import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioItemViewFilesComponent } from 'src/app/components/mike-scenario/mike-scenario-item-view-files/mike-scenario-item-view-files.component';

describe('MikeScenarioItemViewFilesComponent', () => {
  let component: MikeScenarioItemViewFilesComponent;
  let fixture: ComponentFixture<MikeScenarioItemViewFilesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemViewFilesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemViewFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
