import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MWQMRunTVItemListItemMenuComponent } from 'src/app/components/mwqm-run/mwqm-run-tvitem-list-item-menu/mwqm-run-tvitem-list-item-menu.component';

describe('MWQMRunTVItemListItemMenuComponent', () => {
  let component: MWQMRunTVItemListItemMenuComponent;
  let fixture: ComponentFixture<MWQMRunTVItemListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MWQMRunTVItemListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMRunTVItemListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
