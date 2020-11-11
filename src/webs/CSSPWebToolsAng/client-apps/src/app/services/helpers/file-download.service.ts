import { Injectable, Inject } from '@angular/core'
import { HttpClient, HttpRequest } from '@angular/common/http'
import { download, Download } from './file-download'
import { map } from 'rxjs/operators'
import { Observable } from 'rxjs'
import { SAVER, Saver } from './saver.provider'
import { TVFileModel } from 'src/app/models/generated/TVFileModel.model'
import { AppLoadedService } from '../app-loaded.service'
import { AppStateService } from '../app-state.service'

@Injectable({ providedIn: 'root' })
export class DownloadService {

  constructor(
    private appLoadedService: AppLoadedService,
    private appStateService: AppStateService,
    private http: HttpClient,
    @Inject(SAVER) private save: Saver
  ) {
  }

  download(tvFileModel: TVFileModel): Observable<Download> {
    let url: string = `${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/download/${tvFileModel.ParentTVItemID}/${tvFileModel.TVFile.ServerFileName}`;

    return this.http.get(url, {
      reportProgress: true,
      observe: 'events',
      responseType: 'blob'
    }).pipe(download(blob => this.save(blob, tvFileModel.TVFile.ServerFileName)))
  }


  blob(url: string, filename?: string): Observable<Blob> {
    return this.http.get(url, {
      responseType: 'blob'
    })
  }
}