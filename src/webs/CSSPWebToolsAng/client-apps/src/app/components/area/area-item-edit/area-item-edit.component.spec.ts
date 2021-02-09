import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AreaItemEditComponent } from 'src/app/components/area/area-item-edit/area-item-edit.component';

describe('AreaItemEditComponent', () => {
  let component: AreaItemEditComponent;
  let fixture: ComponentFixture<AreaItemEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ AreaItemEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
