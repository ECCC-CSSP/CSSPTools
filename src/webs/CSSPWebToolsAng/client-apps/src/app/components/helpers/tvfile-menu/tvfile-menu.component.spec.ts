import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVFileMenuComponent } from 'src/app/components/helpers/tvfile-menu/tvfile-menu.component';

describe('TVFileMenuComponent', () => {
  let component: TVFileMenuComponent;
  let fixture: ComponentFixture<TVFileMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVFileMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVFileMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
