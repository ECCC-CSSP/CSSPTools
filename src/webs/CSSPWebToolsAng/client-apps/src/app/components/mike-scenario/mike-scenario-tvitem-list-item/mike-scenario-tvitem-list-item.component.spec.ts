import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MikeScenarioTVItemListItemComponent } from 'src/app/components/mike-scenario/mike-scenario-tvitem-list-item/mike-scenario-tvitem-list-item.component';

describe('MikeScenarioTVItemListItemComponent', () => {
  let component: MikeScenarioTVItemListItemComponent;
  let fixture: ComponentFixture<MikeScenarioTVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioTVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioTVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
