import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PolSourceSiteItemMenuOpenComponent } from 'src/app/components/pol-source-site/pol-source-site-item-menu-open/pol-source-site-item-menu-open.component';

describe('PolSourceSiteItemMenuOpenComponent', () => {
  let component: PolSourceSiteItemMenuOpenComponent;
  let fixture: ComponentFixture<PolSourceSiteItemMenuOpenComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteItemMenuOpenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteItemMenuOpenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
