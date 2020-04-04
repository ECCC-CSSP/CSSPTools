import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnumsComponent } from './enums.component';

describe('EnumsComponent', () => {
  let component: EnumsComponent;
  let fixture: ComponentFixture<EnumsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnumsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnumsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
