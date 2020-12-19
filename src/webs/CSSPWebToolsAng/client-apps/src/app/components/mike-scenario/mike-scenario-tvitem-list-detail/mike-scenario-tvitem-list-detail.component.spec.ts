import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MikeScenarioTVItemListDetailComponent } from 'src/app/components/mike-scenario/mike-scenario-tvitem-list-detail/mike-scenario-tvitem-list-detail.component';

describe('MikeScenarioTVItemListDetailComponent', () => {
  let component: MikeScenarioTVItemListDetailComponent;
  let fixture: ComponentFixture<MikeScenarioTVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MikeScenarioTVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MikeScenarioTVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
