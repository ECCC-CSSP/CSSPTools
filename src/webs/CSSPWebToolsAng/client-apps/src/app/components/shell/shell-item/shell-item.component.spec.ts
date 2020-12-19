import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShellItemComponent } from 'src/app/components/shell/shell-item/shell-item.component';

describe('ShellItemComponent', () => {
  let component: ShellItemComponent;
  let fixture: ComponentFixture<ShellItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShellItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShellItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
