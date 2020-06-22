import { Component, OnInit, OnDestroy, ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { PageSelectionService } from 'src/app/services/page-selection.service';
import { Page } from 'src/app/models/Page';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-page-content',
  templateUrl: './page-content.component.html',
  styleUrls: ['./page-content.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PageContentComponent implements OnInit, OnDestroy {
  private subs = new SubSink();
  constructor(private pageSelectionService: PageSelectionService,
              private cd: ChangeDetectorRef) { }

  selectedPageId: number;

  ngOnInit(): void {
    this.subs.sink = this.pageSelectionService.getSelectedPages().subscribe((page: Page) => {
      this.selectedPageId = page.Id;
      this.cd.markForCheck();
    });
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
