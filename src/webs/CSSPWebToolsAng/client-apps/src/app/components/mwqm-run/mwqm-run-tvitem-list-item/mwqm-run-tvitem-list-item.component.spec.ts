import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MWQMRunTVItemListItemComponent } from 'src/app/components/mwqm-run/mwqm-run-tvitem-list-item/mwqm-run-tvitem-list-item.component';

describe('MWQMRunTVItemListItemComponent', () => {
  let component: MWQMRunTVItemListItemComponent;
  let fixture: ComponentFixture<MWQMRunTVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MWQMRunTVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMRunTVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
