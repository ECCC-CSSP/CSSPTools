import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvinceItemEditComponent } from 'src/app/components/province/province-item-edit/province-item-edit.component';

describe('ProvinceItemEditComponent', () => {
  let component: ProvinceItemEditComponent;
  let fixture: ComponentFixture<ProvinceItemEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvinceItemEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinceItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
