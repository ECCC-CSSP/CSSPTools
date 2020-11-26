import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemSubsectorComponent } from 'src/app/components/tvitems/tvitem-list-item-subsector/tvitem-list-item-subsector.component';

describe('TVItemListItemSubsectorComponent', () => {
  let component: TVItemListItemSubsectorComponent;
  let fixture: ComponentFixture<TVItemListItemSubsectorComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemSubsectorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemSubsectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
