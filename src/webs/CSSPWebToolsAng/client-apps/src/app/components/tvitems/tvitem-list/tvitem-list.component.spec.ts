import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListComponent } from './tvitem-list.component';

describe('TVItemListComponent', () => {
  let component: TVItemListComponent;
  let fixture: ComponentFixture<TVItemListComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
