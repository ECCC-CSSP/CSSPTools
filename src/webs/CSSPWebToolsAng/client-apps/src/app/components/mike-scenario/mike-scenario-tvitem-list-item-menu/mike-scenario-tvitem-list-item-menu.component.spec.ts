import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MikeScenarioTVItemListItemMenuComponent } from 'src/app/components/mike-scenario/mike-scenario-tvitem-list-item-menu/mike-scenario-tvitem-list-item-menu.component';

describe('MikeScenarioTVItemListItemMenuComponent', () => {
  let component: MikeScenarioTVItemListItemMenuComponent;
  let fixture: ComponentFixture<MikeScenarioTVItemListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioTVItemListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioTVItemListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
