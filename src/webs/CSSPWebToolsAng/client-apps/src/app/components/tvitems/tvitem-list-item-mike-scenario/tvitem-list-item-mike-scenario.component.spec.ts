import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemMikeScenarioComponent } from 'src/app/components/tvitems/tvitem-list-item-mike-scenario/tvitem-list-item-mike-scenario.component';

describe('TVItemListItemMikeScenarioComponent', () => {
  let component: TVItemListItemMikeScenarioComponent;
  let fixture: ComponentFixture<TVItemListItemMikeScenarioComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemMikeScenarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemMikeScenarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
