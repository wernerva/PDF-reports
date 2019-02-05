import {Component} from '@angular/core';
import {FileOpenerService, IFileData} from './file-opener.service';
import {HttpClient} from '@angular/common/http';
import {environment} from "../environments/environment";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'PDF Generator Demo';

  constructor(private fileOpenerSvc: FileOpenerService, private http: HttpClient) {
  }

  public getReport(): void {
    this.http.get(`${environment.serviceUrl}api/fooreports/`).toPromise().then(
      fileData => this.fileOpenerSvc.openDownload(fileData),
      err => console.log(err)
    );
  }
}
