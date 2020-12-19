import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MWQMSiteTVItemListItemSpecialComponent } from 'src/app/components/mwqm-site/mwqm-site-tvitem-list-item-special/mwqm-site-tvitem-list-item-special.component';

describe('MWQMSiteTVItemListItemSpecialComponent', () => {
  let component: MWQMSiteTVItemListItemSpecialComponent;
  let fixture: ComponentFixture<MWQMSiteTVItemListItemSpecialComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteTVItemListItemSpecialComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteTVItemListItemSpecialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
