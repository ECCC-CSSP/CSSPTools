import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeTestComponent } from 'src/app/components/home/home-test/home-test.component';

describe('HomeTestComponent', () => {
  let component: HomeTestComponent;
  let fixture: ComponentFixture<HomeTestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeTestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
