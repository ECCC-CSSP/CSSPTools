import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MWQMSiteTVItemListItemMenuComponent } from 'src/app/components/mwqm-site/mwqm-site-tvitem-list-item-menu/mwqm-site-tvitem-list-item-menu.component';

describe('MWQMSiteTVItemListItemMenuComponent', () => {
  let component: MWQMSiteTVItemListItemMenuComponent;
  let fixture: ComponentFixture<MWQMSiteTVItemListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteTVItemListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteTVItemListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
