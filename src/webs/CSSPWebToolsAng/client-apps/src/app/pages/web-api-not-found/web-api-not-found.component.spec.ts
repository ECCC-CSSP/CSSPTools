import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WebApiNotFoundComponent } from './web-api-not-found.component';

describe('WebApiNotFoundComponent', () => {
  let component: WebApiNotFoundComponent;
  let fixture: ComponentFixture<WebApiNotFoundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WebApiNotFoundComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WebApiNotFoundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
