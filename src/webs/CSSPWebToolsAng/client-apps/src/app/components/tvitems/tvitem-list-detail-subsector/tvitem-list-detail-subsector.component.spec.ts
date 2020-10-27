import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailSubsectorComponent } from './tvitem-list-detail-subsector.component';

describe('TVItemListDetailSubsectorComponent', () => {
  let component: TVItemListDetailSubsectorComponent;
  let fixture: ComponentFixture<TVItemListDetailSubsectorComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailSubsectorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailSubsectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
