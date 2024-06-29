import { AfterViewInit, Component, ElementRef, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ArContent } from 'src/app/models/ar_content.model';
import { ArService } from 'src/app/services/ar/ar.service';

@Component({
  selector: 'app-arview',
  templateUrl: './arview.page.html',
  styleUrls: ['./arview.page.scss'],
})
export class ARViewPage {
  selectedElevation!: number;
  arContentUrl: SafeUrl = '';

  constructor(private arContentService: ArService, private sanitizer: DomSanitizer) {}

  loadArContent() {
    this.arContentService.getArContentView(this.selectedElevation).subscribe(htmlContent => {
      const blob = new Blob([htmlContent], { type: 'text/html' });
      const url = URL.createObjectURL(blob);
      this.arContentUrl = this.sanitizer.bypassSecurityTrustResourceUrl(url);
    });
  }
}
