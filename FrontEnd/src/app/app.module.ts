import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FileOpenerService } from './services/file-opener.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ServerSideReportComponent } from './components/server-side-report/server-side-report.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatButtonModule,
  MatCardModule,
  MatFormFieldModule,
  MatInputModule,
  MatRadioModule,
  MatTabsModule
} from '@angular/material';
import { PdfFromHtmlComponent } from './components/pdf-from-html/pdf-from-html.component';

@NgModule({
  declarations: [AppComponent, ServerSideReportComponent, PdfFromHtmlComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatInputModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatRadioModule
  ],
  providers: [FileOpenerService],
  bootstrap: [AppComponent]
})
export class AppModule {}
