import { Component, OnInit, OnDestroy } from '@angular/core';
import { plainToClass } from 'class-transformer';
import { PageService } from 'src/app/services/Page.service';
import { Page } from 'src/app/models/Page';
import { MatSelectionListChange } from '@angular/material/list';
import { PageSelectionService } from 'src/app/services/page-selection.service';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-page-list',
  templateUrl: './pages.component.html',
  styleUrls: ['./pages.component.css']
})
export class PagesComponent implements OnInit, OnDestroy {
  private subs = new SubSink();

  constructor(private pageService: PageService,
              private pageSelectionService: PageSelectionService) {
  }

  Pages: Page[];
  selectedPage: Page;


  ngOnInit(): void {
    this.loadPages();
  }

  loadPages(): void {
    this.Pages = [];
    this.subs.sink = this.pageService.get().subscribe((data: Page[]) => {
      this.Pages = plainToClass(Page, data);
    }, error => {
      console.log('Error in load pages ! ');
    });
  }

  onPageChange(event: MatSelectionListChange) {
    this.selectedPage = event.option.value;
    this.pageSelectionService.sendSelectedPage(event.option.value);
  }

  deletePage(pageId) {
    this.subs.sink = this.pageService.delete(pageId).subscribe(() => {
      const index = this.Pages.findIndex((t) => t.Id === pageId);
      this.Pages.splice(index, 1);
    }, error => {
      console.log('Error in deleting page ! ');
    });
  }

  updatePage(page) {
    this.pageService.update(page);
  }

  AddPage() {
    this.subs.sink = this.pageService.addNewpage().subscribe((data: Page) => {
      const page = plainToClass(Page, data);
      this.Pages.push(page);
    }, error => {
      console.log('Error in update page ! ');
    });
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
