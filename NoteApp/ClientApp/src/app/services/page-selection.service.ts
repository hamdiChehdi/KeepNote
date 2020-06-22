import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { Page } from '../models/Page';

@Injectable({
  providedIn: 'root'
})
export class PageSelectionService {
  private subject = new Subject<Page>();

  sendSelectedPage(page: Page) {
    this.subject.next(page);
  }

  clearSelection() {
    this.subject.next();
  }

  getSelectedPages(): Observable<Page> {
    return this.subject.asObservable();
  }
}
