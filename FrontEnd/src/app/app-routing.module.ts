import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ServerSideReportComponent } from './components/server-side-report/server-side-report.component';
import { PdfFromHtmlComponent } from './components/pdf-from-html/pdf-from-html.component';

const routes: Routes = [
  { path: '', redirectTo: '/server-side', pathMatch: 'full' },
  { path: 'server-side', component: ServerSideReportComponent },
  { path: 'from-pdfBody', component: PdfFromHtmlComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
