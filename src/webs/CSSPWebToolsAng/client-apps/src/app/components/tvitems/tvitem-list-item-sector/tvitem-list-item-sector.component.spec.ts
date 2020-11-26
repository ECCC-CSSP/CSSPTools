import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemSectorComponent } from 'src/app/components/tvitems/tvitem-list-item-sector/tvitem-list-item-sector.component';

describe('TVItemListItemSectorComponent', () => {
  let component: TVItemListItemSectorComponent;
  let fixture: ComponentFixture<TVItemListItemSectorComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemSectorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemSectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
