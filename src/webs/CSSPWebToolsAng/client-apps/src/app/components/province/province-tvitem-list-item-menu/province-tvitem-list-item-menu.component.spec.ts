import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ProvinceTVItemListItemMenuComponent } from 'src/app/components/area/area-tvitem-list-item-menu/area-tvitem-list-item-menu.component';

describe('ProvinceTVItemListItemMenuComponent', () => {
  let component: ProvinceTVItemListItemMenuComponent;
  let fixture: ComponentFixture<ProvinceTVItemListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ ProvinceTVItemListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinceTVItemListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
