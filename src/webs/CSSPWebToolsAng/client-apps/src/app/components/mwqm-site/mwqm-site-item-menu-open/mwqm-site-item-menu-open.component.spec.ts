import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MWQMSiteItemMenuOpenComponent } from 'src/app/components/mwqm-site/mwqm-site-item-menu-open/mwqm-site-item-menu-open.component';

describe('MWQMSiteItemMenuOpenComponent', () => {
  let component: MWQMSiteItemMenuOpenComponent;
  let fixture: ComponentFixture<MWQMSiteItemMenuOpenComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteItemMenuOpenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteItemMenuOpenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
