import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemComponent } from 'src/app/components/tvitems/tvitem-list-item/tvitem-list-item.component';

describe('TVItemListItemComponent', () => {
  let component: TVItemListItemComponent;
  let fixture: ComponentFixture<TVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
