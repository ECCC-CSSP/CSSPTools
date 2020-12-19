import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RootItemComponent } from 'src/app/components/root/root-item/root-item.component';

describe('RootItemComponent', () => {
  let component: RootItemComponent;
  let fixture: ComponentFixture<RootItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ RootItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RootItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
