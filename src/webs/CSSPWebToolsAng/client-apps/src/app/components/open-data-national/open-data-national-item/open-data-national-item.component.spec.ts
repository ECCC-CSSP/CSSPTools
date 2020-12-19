import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenDataNationalItemComponent } from 'src/app/components/open-data-national/open-data-national-item/open-data-national-item.component';

describe('OpenDataNationalItemComponent', () => {
  let component: OpenDataNationalItemComponent;
  let fixture: ComponentFixture<OpenDataNationalItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ OpenDataNationalItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenDataNationalItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
