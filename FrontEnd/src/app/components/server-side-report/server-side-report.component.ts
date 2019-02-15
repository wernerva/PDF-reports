import { Component, OnInit } from '@angular/core';
import { FileOpenerService } from 'app/services/file-opener.service';
import { HttpClient } from '@angular/common/http';
import { Orientation } from '../../common/Orientation';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-server-side-report',
  templateUrl: './server-side-report.component.html',
  styleUrls: ['./server-side-report.component.css']
})
export class ServerSideReportComponent implements OnInit {
  public Orientation = Orientation;

  constructor(private fileOpenerSvc: FileOpenerService, private http: HttpClient) {}

  ngOnInit() {}

  public getFooReport(orientation: Orientation): void {
    this.http
      .get(`${environment.serviceUrl}api/fooreports/pdf/${orientation}`)
      .toPromise()
      .then(fileData => this.fileOpenerSvc.openDownload(fileData), err => console.log(err));
  }
}
