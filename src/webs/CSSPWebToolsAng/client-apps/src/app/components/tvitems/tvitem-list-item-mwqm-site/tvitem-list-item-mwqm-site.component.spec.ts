import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemMWQMSiteComponent } from 'src/app/components/tvitems/tvitem-list-item-mwqm-site/tvitem-list-item-mwqm-site.component';

describe('TVItemListItemMWQMSiteComponent', () => {
  let component: TVItemListItemMWQMSiteComponent;
  let fixture: ComponentFixture<TVItemListItemMWQMSiteComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemMWQMSiteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemMWQMSiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
