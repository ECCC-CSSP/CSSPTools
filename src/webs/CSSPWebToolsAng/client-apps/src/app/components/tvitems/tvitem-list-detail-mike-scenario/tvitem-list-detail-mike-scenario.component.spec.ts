import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailMikeScenarioComponent } from 'src/app/components/tvitems/tvitem-list-detail-mike-scenario/tvitem-list-detail-mike-scenario.component';

describe('TVItemListDetailMikeScenarioComponent', () => {
  let component: TVItemListDetailMikeScenarioComponent;
  let fixture: ComponentFixture<TVItemListDetailMikeScenarioComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailMikeScenarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailMikeScenarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
