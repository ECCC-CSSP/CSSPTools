import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MWQMSiteItemDetailComponent } from 'src/app/components/mwqm-site/mwqm-site-item-detail/mwqm-site-item-detail.component';

describe('MWQMSiteItemDetailComponent', () => {
  let component: MWQMSiteItemDetailComponent;
  let fixture: ComponentFixture<MWQMSiteItemDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteItemDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteItemDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
