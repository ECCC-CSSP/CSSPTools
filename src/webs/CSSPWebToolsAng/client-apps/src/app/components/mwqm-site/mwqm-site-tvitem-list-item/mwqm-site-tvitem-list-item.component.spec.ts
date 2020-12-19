import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MWQMSiteTVItemListItemComponent } from 'src/app/components/mwqm-site/mwqm-site-tvitem-list-item/mwqm-site-tvitem-list-item.component';

describe('MWQMSiteTVItemListItemComponent', () => {
  let component: MWQMSiteTVItemListItemComponent;
  let fixture: ComponentFixture<MWQMSiteTVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteTVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteTVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
