import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MunicipalityComponent } from 'src/app/components/tvtypes/municipality/municipality.component';

describe('MunicipalityComponent', () => {
  let component: MunicipalityComponent;
  let fixture: ComponentFixture<MunicipalityComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MunicipalityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MunicipalityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
