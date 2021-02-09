import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemMenuComponent } from 'src/app/components/helpers/tvitem-menu/tvitem-menu.component';

describe('TVItemMenuComponent', () => {
  let component: TVItemMenuComponent;
  let fixture: ComponentFixture<TVItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
