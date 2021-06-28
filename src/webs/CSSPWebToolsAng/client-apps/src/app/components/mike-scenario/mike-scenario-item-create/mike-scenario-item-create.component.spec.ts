import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioItemCreateComponent } from 'src/app/components/mike-scenario/mike-scenario-item-create/mike-scenario-item-create.component';

describe('MikeScenarioItemCreateComponent', () => {
  let component: MikeScenarioItemCreateComponent;
  let fixture: ComponentFixture<MikeScenarioItemCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
