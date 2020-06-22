import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Note } from '../models/Note';
import { NoteType } from '../models/NoteType';

const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private http: HttpClient) {
  }

  get(pageId) {
    return this.http.get(API_URL + '/notes/' + pageId);
  }

  delete(noteId) {
    return this.http.delete(API_URL + '/notes/' + noteId);
  }

  update(note: Note) {
    this.http.put(API_URL + '/notes/' + note.Id, note).subscribe(() => {
    }, error => {
      console.log('Error in update note ! ');
    });
  }

  addInfo(pageId) {
    return this.http.post(API_URL + '/notes/', {Content: '', NoteType: NoteType.Information, PageId : pageId});
  }

  addIdea(pageId) {
    return this.http.post(API_URL + '/notes/', {Content: '', NoteType: NoteType.Idea, PageId : pageId});
  }

  addTodo(pageId) {
    return this.http.post(API_URL + '/notes/', {Content: '', NoteType: NoteType.ToDo, PageId : pageId});
  }
}
