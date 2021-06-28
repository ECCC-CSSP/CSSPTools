import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioItemModifyComponent } from 'src/app/components/mike-scenario/mike-scenario-item-modify/mike-scenario-item-modify.component';

describe('MikeScenarioItemModifyComponent', () => {
  let component: MikeScenarioItemModifyComponent;
  let fixture: ComponentFixture<MikeScenarioItemModifyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
