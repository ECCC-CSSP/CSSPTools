// import { HttpErrorResponse, HttpEventType } from '@angular/common/http';
// import { ElementRef, ViewChild } from '@angular/core';
// import { Component, OnInit, OnDestroy, Input } from '@angular/core';
// import { of } from 'rxjs';
// import { catchError, map } from 'rxjs/operators';
// 
// import { AppLoadedService } from 'src/app/services/app-loaded.service';
// import { AppStateService } from 'src/app/services/app-state.service';
// import { FileUploadService } from 'src/app/services/helpers/file-upload.service';

// @Component({
//   selector: 'app-file-upload',
//   templateUrl: './file-upload.component.html',
//   styleUrls: ['./file-upload.component.css'],
// })
// export class FileUploadComponent implements OnInit, OnDestroy {
//   @ViewChild("fileUpload", { static: false }) fileUpload: ElementRef; 
//   files = [];
//   @Input() working: boolean;
  
// //  form: FormGroup;
// //  progress: number = 0;

//   constructor(public appLoadedService: AppLoadedService,
//     public appStateService: AppStateService,
//     //public fb: FormBuilder,
//     public fileUploadService: FileUploadService
//   ) {
//     // this.form = this.fb.group({
//     //   name: [''],
//     //   avatar: [null]
//     // })
//   }

//   ngOnInit() { }

//   ngOnDestroy() { }

//   // uploadFile(event) {
//   //   const file = (event.target as HTMLInputElement).files[0];
//   //   this.form.patchValue({
//   //     avatar: file
//   //   });
//   //   this.form.get('avatar').updateValueAndValidity()
//   // }

//   // submitUpload() {
//   //   this.fileUploadService.Upload(
//   //     this.form.value.name,
//   //     this.form.value.avatar
//   //   ).subscribe((event: HttpEvent<any>) => {
//   //     switch (event.type) {
//   //       case HttpEventType.Sent:
//   //         console.log('Request has been made!');
//   //         break;
//   //       case HttpEventType.ResponseHeader:
//   //         console.log('Response header has been received!');
//   //         break;
//   //       case HttpEventType.UploadProgress:
//   //         this.progress = Math.round(event.loaded / event.total * 100);
//   //         console.log(`Uploaded! ${this.progress}%`);
//   //         break;
//   //       case HttpEventType.Response:
//   //         console.log('User successfully created!', event.body);
//   //         setTimeout(() => {
//   //           this.progress = 0;
//   //         }, 1500);

//   //     }
//   //   })
//   // }

//   uploadFile(file) {
//     const formData = new FormData();
//     formData.append('file', file.data);
//     file.inProgress = true;
//     this.fileUploadService.upload(formData).pipe(
//       map(event => {
//         switch (event.type) {
//           case HttpEventType.UploadProgress:
//             file.progress = Math.round(event.loaded * 100 / event.total);
//             break;
//           case HttpEventType.Response:
//             return event;
//         }
//       }),
//       catchError((error: HttpErrorResponse) => {
//         file.inProgress = false;
//         return of(`${file.data.name} upload failed.`);
//       })).subscribe((event: any) => {
//         if (typeof (event) === 'object') {
//           console.log(event.body);
//         }
//       });
//   }

//   private uploadFiles() {
//     this.fileUpload.nativeElement.value = '';
//     this.files.forEach(file => {
//       this.appStateService.UpdateAppState(<AppState> { Working: true })
//       this.uploadFile(file);
//     });
//     this.appStateService.UpdateAppState(<AppState> { Working: false })
//   }

//   onClick() {
//     const fileUpload = this.fileUpload.nativeElement; fileUpload.onchange = () => {
//       for (let index = 0; index < fileUpload.files.length; index++) {
//         const file = fileUpload.files[index];
//         this.files.push({ data: file, inProgress: false, progress: 0 });
//       }
//       this.uploadFiles();
//       this.appStateService.UpdateAppState(<AppState> { Working: true })
//     };
//     fileUpload.click();
//   }

// }
