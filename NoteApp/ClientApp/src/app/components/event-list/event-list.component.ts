import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit, OnDestroy {
  private subs = new SubSink();

  constructor() { }

  @Input() pageId: number;

  ngOnInit(): void {
    /*this.subs.sink = this.pageSelectionService.getSelectedPages().subscribe((page: Page) => {
      this.SelectedPage = page;
    });*/
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

}
