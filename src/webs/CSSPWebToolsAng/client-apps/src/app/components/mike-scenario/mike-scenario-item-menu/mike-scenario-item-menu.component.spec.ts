import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MikeScenarioItemMenuComponent } from 'src/app/components/mike-scenario/mike-scenario-item-menu/mike-scenario-item-menu.component';

describe('MikeScenarioItemMenuComponent', () => {
  let component: MikeScenarioItemMenuComponent;
  let fixture: ComponentFixture<MikeScenarioItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
