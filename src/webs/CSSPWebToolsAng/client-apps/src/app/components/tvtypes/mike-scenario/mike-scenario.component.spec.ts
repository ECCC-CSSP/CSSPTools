import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioComponent } from 'src/app/components/tvtypes/mike-scenario/mike-scenario.component';

describe('MikeScenarioComponent', () => {
  let component: MikeScenarioComponent;
  let fixture: ComponentFixture<MikeScenarioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
