import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PolSourceSiteTVItemListItemMenuComponent } from 'src/app/components/pol-source-site/pol-source-site-tvitem-list-item-menu/pol-source-site-tvitem-list-item-menu.component';

describe('PolSourceSiteTVItemListItemMenuComponent', () => {
  let component: PolSourceSiteTVItemListItemMenuComponent;
  let fixture: ComponentFixture<PolSourceSiteTVItemListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteTVItemListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteTVItemListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
