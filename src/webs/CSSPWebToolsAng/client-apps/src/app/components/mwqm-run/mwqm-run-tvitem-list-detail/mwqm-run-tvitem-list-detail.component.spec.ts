import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MWQMRunTVItemListDetailComponent } from 'src/app/components/mwqm-run/mwqm-run-tvitem-list-detail/mwqm-run-tvitem-list-detail.component';

describe('MWQMRunTVItemListDetailComponent', () => {
  let component: MWQMRunTVItemListDetailComponent;
  let fixture: ComponentFixture<MWQMRunTVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MWQMRunTVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMRunTVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
