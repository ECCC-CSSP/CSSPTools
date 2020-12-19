import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AreaTVItemListItemComponent } from 'src/app/components/area/area-tvitem-list-item/area-tvitem-list-item.component';

describe('AreaTVItemListItemComponent', () => {
  let component: AreaTVItemListItemComponent;
  let fixture: ComponentFixture<AreaTVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ AreaTVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaTVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
