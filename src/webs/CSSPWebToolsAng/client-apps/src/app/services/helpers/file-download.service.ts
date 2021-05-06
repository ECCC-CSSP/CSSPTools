// import { Injectable, Inject } from '@angular/core'
// import { HttpClient } from '@angular/common/http'
// import { Observable } from 'rxjs'
// import { download, Download } from 'src/app/services/helpers/file-download'
// import { SAVER, Saver } from 'src/app/services/helpers/saver.provider'
// import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model'
// import { AppLoadedService } from 'src/app/services/app-loaded.service'
// import { AppStateService } from 'src/app/services/app-state.service'

// @Injectable({ providedIn: 'root' })
// export class DownloadService {

//   constructor(
//     private appLoadedService: AppLoadedService,
//     private appStateService: AppStateService,
//     private http: HttpClient,
//     @Inject(SAVER) private save: Saver
//   ) {
//   }

//   download(tvFileModel: TVFileModel): Observable<Download> {
//     let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/download/${tvFileModel.TVItem.ParentID}/${tvFileModel.TVFile.ServerFileName}`;

//     return this.http.get(url, {
//       reportProgress: true,
//       observe: 'events',
//       responseType: 'blob'
//     }).pipe(download(blob => this.save(blob, tvFileModel.TVFile.ServerFileName)))
//   }


//   blob(url: string, filename?: string): Observable<Blob> {
//     return this.http.get(url, {
//       responseType: 'blob'
//     })
//   }
// }