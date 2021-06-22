import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualPlumesItemInputAmbientComponent } from 'src/app/components/visual-plumes/visual-plumes-item-input-ambient/visual-plumes-item-input-ambient.component';

describe('VisualPlumesItemInputAmbientComponent', () => {
  let component: VisualPlumesItemInputAmbientComponent;
  let fixture: ComponentFixture<VisualPlumesItemInputAmbientComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ VisualPlumesItemInputAmbientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualPlumesItemInputAmbientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
