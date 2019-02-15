import { Margins } from './margins';

export interface HtmlToPdfRequest {
  orientation: number;
  pdfHeader: string;
  pdfBody: string;
  pdfFooter: string;
  margins: Margins;
}
