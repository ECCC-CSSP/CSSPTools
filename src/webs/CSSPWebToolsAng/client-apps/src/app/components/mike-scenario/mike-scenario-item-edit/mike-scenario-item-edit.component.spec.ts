import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioItemEditComponent } from 'src/app/components/mike-scenario/mike-scenario-item-edit/mike-scenario-item-edit.component';

describe('MikeScenarioItemEditComponent', () => {
  let component: MikeScenarioItemEditComponent;
  let fixture: ComponentFixture<MikeScenarioItemEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
