import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemMenuOpenComponent } from 'src/app/components/tvitem/tvitem-menu-open/tvitem-menu-open.component';

describe('TVItemMenuOpenComponent', () => {
  let component: TVItemMenuOpenComponent;
  let fixture: ComponentFixture<TVItemMenuOpenComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemMenuOpenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemMenuOpenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
