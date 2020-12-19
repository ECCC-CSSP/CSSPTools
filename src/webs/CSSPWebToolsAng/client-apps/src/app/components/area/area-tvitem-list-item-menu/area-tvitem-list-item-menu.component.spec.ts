import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AreaTVItemListItemMenuComponent } from 'src/app/components/area/area-tvitem-list-item-menu/area-tvitem-list-item-menu.component';

describe('AreaTVItemListItemMenuComponent', () => {
  let component: AreaTVItemListItemMenuComponent;
  let fixture: ComponentFixture<AreaTVItemListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ AreaTVItemListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaTVItemListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
