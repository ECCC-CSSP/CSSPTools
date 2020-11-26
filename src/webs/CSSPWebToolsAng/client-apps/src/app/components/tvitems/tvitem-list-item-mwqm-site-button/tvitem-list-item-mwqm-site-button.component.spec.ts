import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemMWQMSiteButtonComponent } from 'src/app/components/tvitems/tvitem-list-item-mwqm-site-button/tvitem-list-item-mwqm-site-button.component';

describe('TVItemListItemMWQMSiteButtonComponent', () => {
  let component: TVItemListItemMWQMSiteButtonComponent;
  let fixture: ComponentFixture<TVItemListItemMWQMSiteButtonComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemMWQMSiteButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemMWQMSiteButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
