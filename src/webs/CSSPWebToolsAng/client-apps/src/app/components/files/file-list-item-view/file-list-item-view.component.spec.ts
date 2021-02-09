import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListItemViewComponent } from 'src/app/components/files/file-list-item-view/file-list-item-view.component';

describe('FileListItemViewComponent', () => {
  let component: FileListItemViewComponent;
  let fixture: ComponentFixture<FileListItemViewComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
