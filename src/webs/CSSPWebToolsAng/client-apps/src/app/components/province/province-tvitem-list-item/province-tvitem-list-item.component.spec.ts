import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ProvinceTVItemListItemComponent } from 'src/app/components/province/tvitem-list-item-province/tvitem-list-item-province.component';

describe('ProvinceTVItemListItemComponent', () => {
  let component: ProvinceTVItemListItemComponent;
  let fixture: ComponentFixture<ProvinceTVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ ProvinceTVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinceTVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
