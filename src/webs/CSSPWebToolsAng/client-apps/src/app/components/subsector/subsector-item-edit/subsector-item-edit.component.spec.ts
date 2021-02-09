import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubsectorItemEditComponent } from 'src/app/components/subsector/subsector-item-edit/subsector-item-edit.component';

describe('SubsectorItemEditComponent', () => {
  let component: SubsectorItemEditComponent;
  let fixture: ComponentFixture<SubsectorItemEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SubsectorItemEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubsectorItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
