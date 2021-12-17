import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TVItemDeleteComponent } from 'src/app/components/tvitem/tvitem-delete/tvitem-delete.component';

describe('TVItemDeleteComponent', () => {
  let component: TVItemDeleteComponent;
  let fixture: ComponentFixture<TVItemDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ TVItemDeleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
