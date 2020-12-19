import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioItemComponent } from 'src/app/components/mike-scenario/mike-scenario-item/mike-scenario-item.component';

describe('MikeScenarioItemComponent', () => {
  let component: MikeScenarioItemComponent;
  let fixture: ComponentFixture<MikeScenarioItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
