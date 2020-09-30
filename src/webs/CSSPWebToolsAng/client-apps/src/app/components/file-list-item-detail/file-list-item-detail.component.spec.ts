import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListItemDetailComponent } from './file-list-item-detail.component';

describe('FileListItemDetailComponent', () => {
  let component: FileListItemDetailComponent;
  let fixture: ComponentFixture<FileListItemDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListItemDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListItemDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
