import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MikeScenarioItemMenuOpenComponent } from 'src/app/components/mike-scenario/mike-scenario-item-menu-open/mike-scenario-item-menu-open.component';

describe('MikeScenarioItemMenuOpenComponent', () => {
  let component: MikeScenarioItemMenuOpenComponent;
  let fixture: ComponentFixture<MikeScenarioItemMenuOpenComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemMenuOpenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemMenuOpenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
