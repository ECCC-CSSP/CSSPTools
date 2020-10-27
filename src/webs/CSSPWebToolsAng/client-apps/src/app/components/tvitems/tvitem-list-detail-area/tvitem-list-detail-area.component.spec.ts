import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailAreaComponent } from './tvitem-list-detail-area.component';

describe('TVItemListDetailAreaComponent', () => {
  let component: TVItemListDetailAreaComponent;
  let fixture: ComponentFixture<TVItemListDetailAreaComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailAreaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
