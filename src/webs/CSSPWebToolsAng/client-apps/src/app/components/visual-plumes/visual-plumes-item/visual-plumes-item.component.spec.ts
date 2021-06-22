import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualPlumesItemComponent } from 'src/app/components/visual-plumes/visual-plumes-item/visual-plumes-item.component';

describe('VisualPlumesItemComponent', () => {
  let component: VisualPlumesItemComponent;
  let fixture: ComponentFixture<VisualPlumesItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ VisualPlumesItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualPlumesItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
