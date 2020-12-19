import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeItemComponent } from 'src/app/components/home/home-item/home-item.component';

describe('HomeItemComponent', () => {
  let component: HomeItemComponent;
  let fixture: ComponentFixture<HomeItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
