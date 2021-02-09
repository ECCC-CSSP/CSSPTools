import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MunicipalityItemEditComponent } from 'src/app/components/municipality/municipality-item-edit/municipality-item-edit.component';

describe('MunicipalityItemEditComponent', () => {
  let component: MunicipalityItemEditComponent;
  let fixture: ComponentFixture<MunicipalityItemEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MunicipalityItemEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MunicipalityItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy(); 
  });
});
