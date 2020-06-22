import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Page } from '../models/Page';

const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class PageService {
  constructor(private http: HttpClient) {
  }

  get() {
    return this.http.get(API_URL + '/pages');
  }

  delete(pageId: number) {
    return this.http.delete(API_URL + '/pages/' + pageId);
  }

  update(page: Page) {
    this.http.put(API_URL + '/pages/' + page.Id, page).subscribe(() => {
    }, error => {
      console.log('Error in update page ! ');
    });
  }

  addNewpage() {
    return this.http.post(API_URL + '/pages/', { Name: 'New page' });
  }
}
