import { Component, OnInit, Input } from '@angular/core';
import { Note } from 'src/app/models/Note';
import { NoteService } from '../../services/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.css']
})
export class NoteComponent implements OnInit {

  constructor(private noteService: NoteService) {
  }

  @Input() NoteData: Note;

  ngOnInit(): void {
  }

  noteModelChange(event: any) {
    this.noteService.update(this.NoteData);
  }

  handleInput(event: KeyboardEvent): void {
    event.stopPropagation();
  }
}
