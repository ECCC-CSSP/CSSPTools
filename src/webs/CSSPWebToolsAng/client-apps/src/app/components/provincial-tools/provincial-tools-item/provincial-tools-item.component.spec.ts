import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvincialToolsItemComponent } from 'src/app/components/provincial-tools/provincial-tools-item/provincial-tools-item.component';

describe('ProvincialToolsItemComponent', () => {
  let component: ProvincialToolsItemComponent;
  let fixture: ComponentFixture<ProvincialToolsItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvincialToolsItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvincialToolsItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
