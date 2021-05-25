import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemOpenMenuComponent } from 'src/app/components/helpers/tvitem-open-menu/tvitem-open-menu.component';

describe('TVItemOpenMenuComponent', () => {
  let component: TVItemOpenMenuComponent;
  let fixture: ComponentFixture<TVItemOpenMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemOpenMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemOpenMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
