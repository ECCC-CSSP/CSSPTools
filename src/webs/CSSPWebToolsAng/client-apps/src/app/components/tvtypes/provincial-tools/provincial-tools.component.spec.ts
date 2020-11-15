import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvincialToolsComponent } from 'src/app/components/tvtypes/provincial-tools/provincial-tools.component';

describe('ProvincialToolsComponent', () => {
  let component: ProvincialToolsComponent;
  let fixture: ComponentFixture<ProvincialToolsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvincialToolsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvincialToolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
