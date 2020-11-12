import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchOptionComponent } from 'src/app/components/helpers/search-option/search-option.component';

describe('SearchOptionComponent', () => {
  let component: SearchOptionComponent;
  let fixture: ComponentFixture<SearchOptionComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ SearchOptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchOptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
