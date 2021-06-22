import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualPlumesItemInputDiffuserComponent } from 'src/app/components/visual-plumes/visual-plumes-item-input-diffuser-diffuser/visual-plumes-item-input-diffuser-diffuser.component';

describe('VisualPlumesItemInputDiffuserComponent', () => {
  let component: VisualPlumesItemInputDiffuserComponent;
  let fixture: ComponentFixture<VisualPlumesItemInputDiffuserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ VisualPlumesItemInputDiffuserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualPlumesItemInputDiffuserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
