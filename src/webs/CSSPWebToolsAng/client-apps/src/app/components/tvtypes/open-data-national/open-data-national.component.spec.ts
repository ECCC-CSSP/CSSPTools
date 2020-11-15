import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenDataNationalComponent } from 'src/app/components/tvtypes/open-data-national/open-data-national.component';

describe('OpenDataNationalComponent', () => {
  let component: OpenDataNationalComponent;
  let fixture: ComponentFixture<OpenDataNationalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ OpenDataNationalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenDataNationalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
