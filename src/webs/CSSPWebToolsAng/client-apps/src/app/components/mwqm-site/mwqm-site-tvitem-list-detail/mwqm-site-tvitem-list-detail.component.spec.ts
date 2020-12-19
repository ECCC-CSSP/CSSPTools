import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MWQMSiteTVItemListDetailComponent } from 'src/app/components/mwqm-site/mwqm-site-tvitem-list-detail/mwqm-site-tvitem-list-detail.component';

describe('MWQMSiteTVItemListDetailComponent', () => {
  let component: MWQMSiteTVItemListDetailComponent;
  let fixture: ComponentFixture<MWQMSiteTVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteTVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteTVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
