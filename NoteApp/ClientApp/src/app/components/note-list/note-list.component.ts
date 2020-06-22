import { Component, OnDestroy, Input, ChangeDetectionStrategy, OnChanges, SimpleChanges, ChangeDetectorRef } from '@angular/core';
import { SubSink } from 'subsink';
import { NoteService } from 'src/app/services/note.service';
import { plainToClass } from 'class-transformer';
import { Note } from 'src/app/models/Note';

@Component({
  selector: 'app-note-list',
  templateUrl: './note-list.component.html',
  styleUrls: ['./note-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class NoteListComponent implements  OnDestroy, OnChanges {

  private subs = new SubSink();
  constructor(private noteService: NoteService,
              private cd: ChangeDetectorRef) { }

  @Input() pageId: number;
  Notes: Note[] = [];

  addInfoNote() {
    this.subs.sink = this.noteService.addInfo(this.pageId).subscribe((data: Note) => {
      const note = plainToClass(Note, data);
      this.Notes.push(note);
    });
  }

  addIdeaNote() {
    this.subs.sink = this.noteService.addIdea(this.pageId).subscribe((data: Note) => {
      const note = plainToClass(Note, data);
      this.Notes.push(note);
    });
  }

  addTodoNote() {
    this.subs.sink = this.noteService.addTodo(this.pageId).subscribe((data: Note) => {
      const note = plainToClass(Note, data);
      this.Notes.push(note);
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    this.subs.sink = this.noteService.get(this.pageId).subscribe((data: Note[]) => {
      this.Notes = plainToClass(Note, data);
      this.cd.markForCheck();
    });
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
