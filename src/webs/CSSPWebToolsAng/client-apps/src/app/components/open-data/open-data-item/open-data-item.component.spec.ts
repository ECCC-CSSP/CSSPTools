import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenDataItemComponent } from 'src/app/components/open-data/open-data-item/open-data-item.component';

describe('OpenDataItemComponent', () => {
  let component: OpenDataItemComponent;
  let fixture: ComponentFixture<OpenDataItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ OpenDataItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenDataItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
