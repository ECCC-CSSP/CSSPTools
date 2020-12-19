import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SubsectorTVItemListItemMenuComponent } from 'src/app/components/subsector/subsector-tvitem-list-item-menu/subsector-tvitem-list-item-menu.component';

describe('SubsectorTVItemListItemMenuComponent', () => {
  let component: SubsectorTVItemListItemMenuComponent;
  let fixture: ComponentFixture<SubsectorTVItemListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ SubsectorTVItemListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubsectorTVItemListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
