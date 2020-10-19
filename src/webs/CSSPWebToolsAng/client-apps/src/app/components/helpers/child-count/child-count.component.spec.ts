import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ChildCountComponent } from './child-count.component';

describe('ChildCountComponent', () => {
  let component: ChildCountComponent;
  let fixture: ComponentFixture<ChildCountComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ ChildCountComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChildCountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
