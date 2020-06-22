import { Component, ChangeDetectionStrategy, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { Page } from 'src/app/models/Page';
import { ClonerService } from '../../services/cloner.service';

@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PageComponent implements OnInit {
  constructor(private clonerService: ClonerService) {
  }

  draftPage: Page;
  disableEdit: boolean;
  @Input() Page: Page;
  @Output() deletePage: EventEmitter<number> = new EventEmitter<number>();
  @Output() PageEdited: EventEmitter<any> = new EventEmitter<any>();

  ngOnInit() {
    this.disableEdit = true;
    this.draftPage = this.clonerService.deepClone(this.Page);
  }

  clickEdit() {
    this.disableEdit = !this.disableEdit;

    if (this.disableEdit) {
      this.PageEdited.emit(this.draftPage);
    }
  }

  clickDelete() {
    this.deletePage.emit(this.draftPage.Id);
  }

  handleInput(event: KeyboardEvent): void {
    event.stopPropagation();
  }
}
