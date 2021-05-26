import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TVItemModifyComponent } from 'src/app/components/tvitem/tvitem-modify/tvitem-modify.component';

describe('TVItemModifyComponent', () => {
  let component: TVItemModifyComponent;
  let fixture: ComponentFixture<TVItemModifyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ TVItemModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
