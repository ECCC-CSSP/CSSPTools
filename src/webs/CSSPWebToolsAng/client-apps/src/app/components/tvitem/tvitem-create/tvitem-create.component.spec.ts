import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TVItemCreateComponent } from 'src/app/components/tvitem/tvitem-create/tvitem-create.component';

describe('TVItemCreateComponent', () => {
  let component: TVItemCreateComponent;
  let fixture: ComponentFixture<TVItemCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ TVItemCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
